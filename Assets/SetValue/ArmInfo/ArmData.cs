[System.Serializable]
    public class ArmData
    {
        public int likeAmount;
        public int repostAmount;
        public int bookmarkAmount;
        public int commentAmount;

        public bool isActive; //これは後からアームを追加したり消したりできるから、その際、後の処理に含まれないようにするための変数です。

    }
