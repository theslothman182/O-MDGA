using OMDGA.VO;
using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;

namespace OMDGA.Views
{
    public class LaneCreepView :
    EventView
    {
        // ****** Private Variables ******
        private string unitName;
        private float health;
        private float healthRegen;
        private float mana;
        private float manaRegen;
        private int level;
        private int armor;
        private int magicResistance;
        private int statusResistance;
        private int attackDamageLower;
        private int attackDamageHigher;
        private int attackRange;
        private int acquisitionRange;
        private int attackSpeed;
        private float attackTime;
        private float attackPoint;
        private float attackBackswing;
        private int projectileSpeed;
        private int movementSpeed;
        private int followRange;
        private float turnRate;
        private int collisionSize;
        private int boundRadius;
        private int visionDay;
        private int visionNight;
        private int bountyLower;
        private int bountyHigher;
        private int experience;

        // ****** Methods ******
        public void SetSpawnStats(LaneCreepData data)
        {
            unitName = data.name;
            health = data.health;
            healthRegen = data.healthRegen;
            mana = data.mana;
            manaRegen = data.manaRegen;
            level = data.level;
            armor = data.armor;
            magicResistance = data.magicResistance;
            statusResistance = data.statusResistance;
            attackDamageLower = data.attackDamageLower;
            attackDamageHigher = data.attackDamageHigher;
            attackRange = data.attackRange;
            acquisitionRange = data.acquisitionRange;
            attackSpeed = data.attackSpeed;
            attackTime = data.attackTime;
            attackPoint = data.attackPoint;
            attackBackswing = data.attackBackswing;
            projectileSpeed = data.projectileSpeed;
            movementSpeed = data.movementSpeed;
            followRange = data.followRange;
            turnRate = data.turnRate;
            collisionSize = data.collisionSize;
            boundRadius = data.boundRadius;
            visionDay = data.visionDay;
            visionNight = data.visionNight;
            bountyLower = data.bountyLower;
            bountyHigher = data.bountyHigher;
            experience = data.experience;
        }
    }
}