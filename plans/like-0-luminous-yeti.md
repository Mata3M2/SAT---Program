# WeightManager → PanelManager 状態通知 実装プラン

## Context（なぜこの変更をするのか）

現状、状態（`WeightType` = Like/Repost/Bookmark/Comment）は `WeightManager` が管理していて、`OnNextButton()` を押すと `currentWeightIndex` が1つ次の enum 値に進む。ここまでは動く状態になっている。

一方 `PanelManager.cs`（`Assets/SetValue/PanelManager.cs`）は、ファイル名とクラス名が一致していない（`class Test`）、`using Unity.UI;` という存在しない名前空間の import、`Update()` 内に壊れた構文（`weightManager.currentWeightIndex[ = `）が残っている、キーボード操作の実験コードが残っている、など複数の理由でコンパイルが通らない状態になっている。これは実験・作業途中のコードだと理解している。

やりたいことは、「`WeightManager` の状態が切り替わった」という事実を `PanelManager` に伝えて、`PanelManager` が該当するパネルだけを表示し、他を隠す、という一方向の連携を組むこと。ユーザーは「①最初にどう送るのか」「②なぜその配置にするのか」「③どう機能するのか」を理解したうえで実装したいとのことなので、プラン自体にその説明を組み込む。

## 採用する設計：C# の `event`（Observer パターン）

以前の会話で「WeightManager が PanelManager を直接呼ぶ方式（方針A）」と「WeightManager がイベントを発行し、PanelManager がそれを購読する方式（方針B）」の2択を提示したが、今回ユーザーが明確に「切り替わった情報を送信して、それを元に相手が動く」という一方向の通知の形を望んでいるため、**方針B（event 通知）** を採用する。

- `WeightManager` は「自分の状態が変わったこと」だけを知らせる。誰が聞いているかは知らない・気にしない。
- `PanelManager` は `WeightManager` の存在を知っていて、変化があったら自分の仕事（パネルの表示切り替え）をする。

この「知らせる側は聞く側を知らない」という非対称な関係が、疎結合（loose coupling）と呼ばれる設計のキモになる。

## ①「最初にどう送るか」への回答

C# の `event` は「何かが起きた瞬間」にしか発火しない。アプリ起動直後はまだ何も「変化」していないので、`OnNextButton()` 経由の event は一度も呼ばれない。つまり **初期表示は event の仕組みの外で、明示的に1回だけ合わせておく必要がある**。

具体的には `PanelManager.Start()` の中で、起動時点の `weightManager.currentWeightIndex` を読み取り、パネル切り替え処理を直接1回呼び出す。以降の切り替えだけを event に任せる。

## ②「なぜその配置か」への回答

| 要素 | 置き場所 | 理由 |
|---|---|---|
| `event` の宣言 (`public event Action<WeightType> OnWeightTypeChanged;`) | `WeightManager` | 状態（`currentWeightIndex`）を所有しているのは WeightManager。状態が変わったことを知らせる責任も、状態の持ち主にあるべき。 |
| `Invoke()`（発行） | `WeightManager.OnNextButton()` の中、`currentWeightIndex` を更新した直後 | 「値が変わった直後」に知らせるのが自然。値を更新する前に知らせると、購読側が古い値を読んでしまう。 |
| 購読 (`+=`) | `PanelManager` の `OnEnable()` | パネルの表示切り替えという「反応」をする責任は PanelManager にある。`OnEnable`/`OnDisable` で購読・解除を対にするのは Unity のイベント購読の定石（オブジェクトが無効化されたときに購読が残って例外になるのを防ぐため）。 |
| パネル切り替えロジック (`ShowPanel`) | `PanelManager` | パネルの配列を持っているのは PanelManager 自身なので、表示ロジックもここに置くのが自然（WeightManager はパネルの存在を一切知らなくてよい）。 |

WeightManager → PanelManager の参照は一方向（PanelManager だけが WeightManager を知っている）。逆方向の参照は不要になる。

## ③「どう機能するか」（実行時の流れ）

1. Unity の UI Button の `OnClick()` に登録された `WeightManager.OnNextButton()` がクリックのたびに1回呼ばれる（これは Unity 側が自動でやってくれる。キーボードのポーリングは不要）。
2. `OnNextButton()` 内で `currentWeightIndex` を次の enum 値に更新する。
3. 更新した直後に `OnWeightTypeChanged?.Invoke(currentWeightIndex)` を呼ぶ。これは「登録されている購読者を今すぐ・同期的に全部呼び出す」という意味（次のフレームまで待ったりしない）。
4. `PanelManager` は `OnEnable()` の時点で `weightManager.OnWeightTypeChanged += ShowPanel;` として自分の `ShowPanel` メソッドを登録済みなので、3. の Invoke によって `ShowPanel(currentWeightIndex)` がその場で実行される。
5. `ShowPanel` は enum を `(int)` にキャストして、`panels` 配列を先頭からループし、「自分のindexと一致するものだけ `SetActive(true)`、それ以外は `false`」にする。

## 変更対象ファイル

### `Assets/SetValue/WeightManager.cs`
- `public event System.Action<WeightType> OnWeightTypeChanged;` を追加。
- `OnNextButton()` 内、`currentWeightIndex = (WeightType)value;` の直後に `OnWeightTypeChanged?.Invoke(currentWeightIndex);` を追加。
- `Start()` に残っている未使用のローカル変数 `int value = (int)currentWeightIndex;`（29行目、何もしていない死んだコード）は削除する。

### `Assets/SetValue/PanelManager.cs`
現状壊れているので、以下の形に立て直す。
- クラス名を `Test` → `PanelManager` に修正（ファイル名と一致させないと Unity にアタッチできない）。
- `using Unity.UI;`（存在しない名前空間）を削除。
- 壊れた構文の `Update()`（スペース/エンターキーで全パネルを一括 ON/OFF する実験コード、20行目の構文エラー含む）を削除。ボタン駆動の設計と衝突するため。
- `[SerializeField] private WeightManager weightManager;` フィールドを追加（Inspector で同じシーン内の WeightManager をアタッチする）。
- `void Start()` で `ShowPanel(weightManager.currentWeightIndex);` を呼び、起動直後の表示を現在の状態に合わせる。
- `void OnEnable()` で `weightManager.OnWeightTypeChanged += ShowPanel;`
- `void OnDisable()` で `weightManager.OnWeightTypeChanged -= ShowPanel;`
- `private void ShowPanel(WeightManager.WeightType type)` を実装。`int index = (int)type;` としたうえで `panels` をループし `panels[i].SetActive(i == index);`

## Unity エディタ側で必要な手動作業（コード変更だけでは動かない部分）

- `PanelManager` コンポーネントの `panels` 配列に、**enum の並び順（Like=0, Repost=1, Bookmark=2, Comment=3）と同じ順番で** 4つの Panel GameObject を Inspector からアタッチする。順番がズレると違うパネルが表示される。
- `PanelManager` コンポーネントの `weightManager` フィールドに、シーン内の `WeightManager` を持つ GameObject をアタッチする。

## 検証方法

1. Unity エディタでコンパイルエラーが消えていることを確認（Console窓）。
2. Play モードに入り、起動直後に Like 用のパネルだけが表示されていることを確認。
3. ボタンを4回連続でクリックし、Repost → Bookmark → Comment → Like の順にパネルが1枚ずつ切り替わり、最後は最初の Like に戻る（`% 4` の巡回）ことを確認。
4. Console に `Debug.Log(currentWeightIndex)` の出力が想定通り出ていることを確認。
