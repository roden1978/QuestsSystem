using System;

namespace QuestsSystem
{
    public class Player : IQuestCompletable
    {
        public event Action<Npc> OnTouchNpc;
        public event Action<GameObject> OnMarkedItemTouch;

        public void TouchNpc(Npc npc)
        {
            OnTouchNpc?.Invoke(npc);
        }

        public void TouchQuestMarkedItem(GameObject gameObject)
        {
            OnMarkedItemTouch?.Invoke(gameObject);
        }
    }
}