using WinFormsCTech;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ResponsibleExecutor
        }

        [Fact]
        public void testAddCompareStartAndEnd()
        {
            MeetingCollection meetingCollection = new MeetingCollection();

            Meeting meeting = new Meeting();
            meeting.Name = "test1";
            meeting.StartTime = DateTime.Parse("28.06.2023 11:45:00");
            meeting.EndTime = DateTime.Parse("01.01.2001 01:00:00");
            meeting.ReminderTime = DateTime.Parse("28.05.2023 11:45:00");

            bool isThereError = false;
            try
            {
                meetingCollection.AddMeeting(meeting);
            }
            catch (Exception ex)
            {
                isThereError = true;
            }

            if (!isThereError)
            {
                throw new Exception("testAddCompareStartAndEnd is fail");
            }
        }
    }
}