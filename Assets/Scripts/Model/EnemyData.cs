[System.Serializable]//讓這個class序列化
    public class EnemyData
    {
        public int health;
        public int willDropItemId;
        public float dropProbability;
        public float defeatTimeLimit;
        public EnemyBehavior enemyPrefab;
    }
	
