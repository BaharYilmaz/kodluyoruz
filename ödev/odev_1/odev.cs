using System;
using System.Collections.Generic;

namespace odev_1
{
    public class odev
    {


        public class VideoCall : IMeeting
        {
            public void makeMeeting()
            {
                makeVideoCall();
            }

            public void makeVideoCall()
            {//video call
            }
        }

        public class VoiceCall : IMeeting
        {
            public void makeMeeting()
            {
                makeVoiceCall();
            }

            public void makeVoiceCall()
            {//voice call
            }
        }

        public class Meeting
        {
            private List<IMeeting> meetings;
            public Meeting(List<IMeeting> _meetings)
            {
                this.meetings = _meetings;
            }

            public void setMeeting()
            {
                foreach (var meeting in meetings)
                {
                    meeting.makeMeeting();
                }
            }
        }

        public interface IMeeting
        {
            void makeMeeting();
        }

    }
}
