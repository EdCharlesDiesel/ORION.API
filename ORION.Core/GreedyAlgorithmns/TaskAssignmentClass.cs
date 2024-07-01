using System.Collections.Generic;

namespace TaskAssignment
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskAssignmentClass
    {
        public List<List<int>> TaskAssignment(int k, List<int> tasks)
        {
            List<List<int>> pairedTasks = new List<List<int>>();
            Dictionary<int, List<int>> taskDurationsToIndices = GetTaskDurationsToIndices(tasks);

            List<int> sortedTasks = tasks;
            sortedTasks.Sort();

            for (int index = 0; index < k; index++)
            {
                int task1Duration = sortedTasks[index];
                List<int> indicesWithTask1Duration = taskDurationsToIndices[task1Duration];
                int task1Index = indicesWithTask1Duration[indicesWithTask1Duration.Count - 1];
                indicesWithTask1Duration.RemoveAt(indicesWithTask1Duration.Count - 1);

                int taskSortedIndex = tasks.Count - 1 - index;
                int task2Duration = sortedTasks[taskSortedIndex];
                List<int> indicesWithTask2Duration = taskDurationsToIndices[task2Duration];

                int task2Index = indicesWithTask1Duration[indicesWithTask1Duration.Count - 1];
                indicesWithTask1Duration.RemoveAt(indicesWithTask1Duration.Count - 1);

                List<int> pairedTask = new List<int>();
                pairedTask.Add(task1Index);
                pairedTask.Add(task2Index);
                pairedTasks.Add(pairedTask);
            }

            return pairedTasks;
        }

        private Dictionary<int, List<int>> GetTaskDurationsToIndices(List<int> tasks)
        {
            Dictionary<int, List<int>> taskDurationsToIndices = new Dictionary<int, List<int>>();

            for (int i = 0; i < tasks.Count; i++)
            {
                int taskDuration = tasks[i];
                if (taskDurationsToIndices.ContainsKey(taskDuration))
                {
                    taskDurationsToIndices[taskDuration].Add(i);
                }
                else
                {
                    List<int> temp = new List<int>();
                    temp.Add(i);
                    taskDurationsToIndices[taskDuration] = temp;
                }
            }

            return taskDurationsToIndices;
        }

        //public List<List<int>> TaskAssignmentSolution(int k, List<int> tasks)
        //{ 
        //    var ret = new List<List<int>>();    
        //    var taskIndexMap = new List<int>();

        //    for (int i = 0; i < tasks.Count; i++)
        //    {
        //        taskIndexMap.Add(new int[] { tasks[i], i });
        //        taskIndexMap.Sort((e1,e2)=> ei[0].CompareTo(e2[0]);
        //    }
        //    return ret;
        //}
    }
}