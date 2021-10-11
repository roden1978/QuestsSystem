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
            var markerRepositoryProvider = new MakerRepositoryProvider(markerRepository, player);

            var questsRepository = new QuestsRepository(new Dictionary<Type, Quest[]>{
                {typeof(Wizard), new Quest[]
                {
                    new KillDragonQuest(0, new KillDragonAgreement(
                        new KillDragonQuestEvent(
                            new KillDragonMarker()
                            ),markerRepositoryProvider)),
                    new CollectApplesQuest(1, new CollectApplesAgreement(
                        new CollectApplesQuestEvent(null), null)),
                    new FindPrincessQuest(2, new FindPrincessAgreement(new FindPrincessQuestEvent(null), null))
                }}
            });
            var provider = new Provider(questsRepository, player);
            
            var npc = new Wizard();
            var dragonKillMarker = new KillDragonMarker();
            var markedGameObject = new DragonTooth(dragonKillMarker);
            var dragon = new Dragon(markedGameObject);

            provider.Subscribe();
            markerRepositoryProvider.Subscribe();
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
            markerRepositoryProvider.Unsubscribe();
            provider.Unsubscribe();
        }
    }
}