namespace ORION.Core.Arrays
{
    public class CreditCardMatchingClass
    {
        // O(c1 + c2) time | O(c1 + c2) space - where c1 and c2 are the respective numbers of meetings in CreditCard1 and CreditCard2
        //public static List<StringMeeting> CreditCardMatchingClass(
        //List<StringMeeting> CreditCard1,
        //StringMeeting dailyBounds1,
        //List<StringMeeting> CreditCard2,
        //StringMeeting dailyBounds2,
        //int meetingDuration
        //)
        //{
        //    List<Meeting> updatedCreditCard1 = updateCreditCard(CreditCard1, dailyBounds1);
        //    List<Meeting> updatedCreditCard2 = updateCreditCard(CreditCard2, dailyBounds2);
        //    List<Meeting> mergedCreditCard = mergeCreditCards(updatedCreditCard1, updatedCreditCard2);
        //    List<Meeting> flattenedCreditCard = flattenCreditCard(mergedCreditCard);
        //    return getMatchingAvailabilities(flattenedCreditCard, meetingDuration);
        //}
        //public static List<Meeting> updateCreditCard(
        //List<StringMeeting> CreditCard,
        //StringMeeting dailyBounds
        //)
        //{
        //    List<StringMeeting> updatedCreditCard = new List<StringMeeting>();
        //    updatedCreditCard.Add(new StringMeeting("0:00", dailyBounds.start));
        //    updatedCreditCard.AddRange(CreditCard);
        //    updatedCreditCard.Add(new StringMeeting(dailyBounds.end, "23:59"));
        //    List<Meeting> CreditCardInMinutes = new List<Meeting>();
        //    for (int i = 0; i < updatedCreditCard.Count; i++)
        //    {
        //        CreditCardInMinutes.Add(new Meeting(
        //        timeToMinutes(updatedCreditCard[i].start),
        //        timeToMinutes(updatedCreditCard[i].end)
        //        ));
        //    }
        //    return CreditCardInMinutes;
        //}
        //public static List<Meeting> mergeCreditCards(
        //List<Meeting> CreditCard1,
        //List<Meeting> CreditCard2
        //)
        //{
        //    List<Meeting> merged = new List<Meeting>();
        //    int i = 0;
        //    int j = 0;
        //    while (i < CreditCard1.Count && j < CreditCard2.Count)
        //    {
        //        Meeting meeting1 = CreditCard1[i];
        //        Meeting meeting2 = CreditCard2[j];
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
        //    while (i < CreditCard1.Count) merged.Add(CreditCard1[i++]);
        //    while (j < CreditCard2.Count) merged.Add(CreditCard2[j++]);
        //    return merged;
        //}
        //public static List<Meeting> flattenCreditCard(List<Meeting> CreditCard)
        //{
        //    List<Meeting> flattened = new List<Meeting>();
        //    flattened.Add(CreditCard[0]);
        //    for (int i = 1; i < CreditCard.Count; i++)
        //    {
        //        Meeting currentMeeting = CreditCard[i];
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
        //List<Meeting> CreditCard,
        //int meetingDuration
        //)
        //{
        //    List<Meeting> matchingAvailabilities = new List<Meeting>();
        //    for (int i = 1; i < CreditCard.Count; i++)
        //    {
        //        int start = CreditCard[i - 1].end;
        //        int end = CreditCard[i].start;
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
