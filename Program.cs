using System.Collections.Generic;
using System;

namespace QuestsSystem
{
    class Program
    {
        private static void Main(string[] args)
        {
            var player = new Player();
            var markerRepository = new MarkerRepository();

            var questsRepository = new QuestsRepository(new Dictionary<Type, Quest[]>{
                {typeof(Wizard), new Quest[]
                {
                    new KillDragonQuest(0, 
                        new KillDragonAgreement(new KillDragonMarker()), 
                        new KillDragonQuestEvent()),
                    new CollectApplesQuest(1, 
                        new CollectApplesAgreement(null), 
                        new CollectApplesQuestEvent()),
                    new FindPrincessQuest(2, 
                        new FindPrincessAgreement(null), 
                        new FindPrincessQuestEvent())
                }
                }
            });
            var provider = new Provider(player, questsRepository, markerRepository);
            
            var npc = new Wizard();
            var dragonKillMarker = new KillDragonMarker();
            var markedGameObject = new DragonTooth(dragonKillMarker);
            var dragon = new Dragon(markedGameObject);

            provider.Subscribe();
            Console.WriteLine("Follow to Wizard for quest");
            player.TouchNpc(npc);
            Console.WriteLine("Take the quest 'Kill the Dragon in the forest'");
            //player kill dragon
            Console.WriteLine("Player kill the Dragon. The dragon leaves his tooth.");
            var markedItem = dragon.Die();
            //player take marked item
            Console.WriteLine("Player give the tooth to inventory.");
            player.TouchQuestMarkedItem(markedItem);
            Console.WriteLine("Back to the Wizard after complete quest");
            player.TouchNpc(npc);
            provider.Unsubscribe();
        }
    }
}