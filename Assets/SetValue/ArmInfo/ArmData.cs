[System.Serializable]

/*
アームの数値を管理し、保持しています。ArmDataクラスは、各アームのLike、Repost、Bookmark、コメントの数値を保持するためのデータ構造です。
*/
    public class ArmData
    {
        public int likeAmount;
        public int repostAmount;
        public int bookmarkAmount;
        public int commentAmount;

        public bool isActive; //これは後からアームを追加したり消したりできるから、その際、後の処理に含まれないようにするための変数です。

    }
