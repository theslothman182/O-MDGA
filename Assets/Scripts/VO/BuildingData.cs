// usings

namespace OMDGA.VO
{
    [System.Serializable]
    public class BuildingData
    {
		// ****** Public Variables ******
        public string name;
		public int health;
		public float healthRegen;
		public int armor;
		public int magicResistance;
		public int attackDamageLower;
		public int attackDamageHigher;
		public int attackRange;
		public int acquisitionRange;
		public int attackSpeed;
		public float attackTime;
		public float attackPoint;
		public float attackBackswing;
		public int projectileSpeed;
		public int collisionSize;
		public int boundRadius;
		public int visionDay;
		public int visionNight;
		public int bountyLower;
		public int bountyHigher;
		public int teamBounty;
    }
}