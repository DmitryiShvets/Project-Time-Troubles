
namespace Core.Events
{
    /// <summary>
    /// Этот ивент будет начинать квест (который прикреплен к нпс)
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
                quest.OnStartQuest(); // Спавн предметов для квеста
                npc.StartQuest(quest); // Сказать нпс что у него появился активный квест
            }
        }
    }
}