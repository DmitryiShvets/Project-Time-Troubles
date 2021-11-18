
namespace Core.Events
{
    /// <summary>
    /// This event will start a quest (which is attached to an NPC).
    /// </summary>
    /// <typeparam name="StartQuest"></typeparam>
    public class StartQuest : Event<StartQuest>
    {
        public Quest quest;
        public NPCController npc;

        public override void Execute()
        {
            if (!quest.isStarted)
            {
                quest.isStarted = true;
                quest.OnStartQuest();
                npc.StartQuest(quest);
            }
        }
    }
}