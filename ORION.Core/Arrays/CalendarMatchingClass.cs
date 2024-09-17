namespace ORION.Core.Arrays
{
    public class SalesPersonMatchingClass
    {
        // O(c1 + c2) time | O(c1 + c2) space - where c1 and c2 are the respective numbers of meetings in SalesPerson1 and SalesPerson2
        //public static List<StringMeeting> SalesPersonMatchingClass(
        //List<StringMeeting> SalesPerson1,
        //StringMeeting dailyBounds1,
        //List<StringMeeting> SalesPerson2,
        //StringMeeting dailyBounds2,
        //int meetingDuration
        //)
        //{
        //    List<Meeting> updatedSalesPerson1 = updateSalesPerson(SalesPerson1, dailyBounds1);
        //    List<Meeting> updatedSalesPerson2 = updateSalesPerson(SalesPerson2, dailyBounds2);
        //    List<Meeting> mergedSalesPerson = mergeSalesPersons(updatedSalesPerson1, updatedSalesPerson2);
        //    List<Meeting> flattenedSalesPerson = flattenSalesPerson(mergedSalesPerson);
        //    return getMatchingAvailabilities(flattenedSalesPerson, meetingDuration);
        //}
        //public static List<Meeting> updateSalesPerson(
        //List<StringMeeting> SalesPerson,
        //StringMeeting dailyBounds
        //)
        //{
        //    List<StringMeeting> updatedSalesPerson = new List<StringMeeting>();
        //    updatedSalesPerson.Add(new StringMeeting("0:00", dailyBounds.start));
        //    updatedSalesPerson.AddRange(SalesPerson);
        //    updatedSalesPerson.Add(new StringMeeting(dailyBounds.end, "23:59"));
        //    List<Meeting> SalesPersonInMinutes = new List<Meeting>();
        //    for (int i = 0; i < updatedSalesPerson.Count; i++)
        //    {
        //        SalesPersonInMinutes.Add(new Meeting(
        //        timeToMinutes(updatedSalesPerson[i].start),
        //        timeToMinutes(updatedSalesPerson[i].end)
        //        ));
        //    }
        //    return SalesPersonInMinutes;
        //}
        //public static List<Meeting> mergeSalesPersons(
        //List<Meeting> SalesPerson1,
        //List<Meeting> SalesPerson2
        //)
        //{
        //    List<Meeting> merged = new List<Meeting>();
        //    int i = 0;
        //    int j = 0;
        //    while (i < SalesPerson1.Count && j < SalesPerson2.Count)
        //    {
        //        Meeting meeting1 = SalesPerson1[i];
        //        Meeting meeting2 = SalesPerson2[j];
        //        if (meeting1.start < meeting2.start)
        //        {
        //            merged.Add(meeting1);
        //            i++;
        //        }
        //        else
        //        {
        //            merged.Add(meeting2);
        //            j++;
        //        }
        //    }
        //    while (i < SalesPerson1.Count) merged.Add(SalesPerson1[i++]);
        //    while (j < SalesPerson2.Count) merged.Add(SalesPerson2[j++]);
        //    return merged;
        //}
        //public static List<Meeting> flattenSalesPerson(List<Meeting> SalesPerson)
        //{
        //    List<Meeting> flattened = new List<Meeting>();
        //    flattened.Add(SalesPerson[0]);
        //    for (int i = 1; i < SalesPerson.Count; i++)
        //    {
        //        Meeting currentMeeting = SalesPerson[i];
        //        Meeting previousMeeting = flattened[flattened.Count - 1];
        //        if (previousMeeting.end >= currentMeeting.start)
        //        {
        //            Meeting newPreviousMeeting = new Meeting(
        //            previousMeeting.start,
        //            Math.Max(previousMeeting.end, currentMeeting.end)
        //            );
        //            flattened[flattened.Count - 1] = newPreviousMeeting;
        //        }
        //        else
        //        {
        //            flattened.Add(currentMeeting);
        //        }
        //    }
        //    return flattened;
        //}
        //public static List<StringMeeting> getMatchingAvailabilities(
        //List<Meeting> SalesPerson,
        //int meetingDuration
        //)
        //{
        //    List<Meeting> matchingAvailabilities = new List<Meeting>();
        //    for (int i = 1; i < SalesPerson.Count; i++)
        //    {
        //        int start = SalesPerson[i - 1].end;
        //        int end = SalesPerson[i].start;
        //        int availabilityDuration = end - start;
        //        if (availabilityDuration >= meetingDuration)
        //        {
        //            matchingAvailabilities.Add(new Meeting(start, end));
        //        }
        //    }
        //    List<StringMeeting> matchingAvailabilitiesInHours = new List<StringMeeting>();
        //    for (int i = 0; i < matchingAvailabilities.Count; i++)
        //    {
        //        matchingAvailabilitiesInHours.Add(new StringMeeting(
        //        minutesToTime(
        //        matchingAvailabilities[i].
        //        start),
        //        minutesToTime(
        //        matchingAvailabilities[i].
        //        end)
        //        ));
        //    }
        //    return matchingAvailabilitiesInHours;
        //}
        //public static int timeToMinutes(string time)
        //{
        //    int delimiterPos = time.IndexOf(":");
        //    int hours = Int32.Parse(time.Substring(0, delimiterPos));
        //    int minutes = Int32.Parse(time.Substring(delimiterPos + 1));
        //    return hours * 60 + minutes;
        //}

        //public static string minutesToTime(int minutes)
        //{
        //}
    }

    internal class StringMeeting
    {
  
                    public int start;
        public int end;

        public StringMeeting(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
    }
