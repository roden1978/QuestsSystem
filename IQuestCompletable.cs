using System;

namespace QuestsSystem
{
    public interface IQuestCompletable
    {
        public event Action<Npc> OnTouchNpc;
        public event Action<GameObject> OnMarkedItemTouch;

        public void TouchNpc(Npc npc);
        public void TouchQuestMarkedItem(GameObject markedItem);
    }
}