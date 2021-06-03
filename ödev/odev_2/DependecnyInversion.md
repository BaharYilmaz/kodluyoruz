### Dependency Inversion - Bağımlılığı Tersine Çevirme

Projelerimizin esnek ve yeniden kullanılabilir olması için farklı prensipleri ve teknikleri kullanmamız gerekir. Dependency Inversion da yazılımın bağımlılığını azaltan ve onu daha esnek hale getiren bir SOLID prensibidir.
Kullandığımız herhangi bir sınıf veya metodun onu kullanan diğer sınıflara karşı bağımlılığı mümkün olduğunca az olmalıdır. Başka sınıflarda meydana gelen bir değişiklik ana sınıfımızı etkilememelidir.

Örnek olarak bir şirketin yaptığı toplantı biçimlerini düşünelim.Toplantıyı gerçekleştirmek için görüntülü görüşme veya sesli görüşme ile toplantı yaptıklarını düşünelim. 

Dependency Inversion prensibini uygulamadığımızda kodumuz yaklaşık bu şekilde görünecektir.


```
        public class VideoCall
        {
            public void makeVideoCall()
            {
            }
        }

        public class VoiceCall
        {
            public void makeVoiceCall()
            {
            }
        }

        public class Meeting
        {
            private VideoCall videoCall = new VideoCall();
            private VoiceCall voiceCall = new VoiceCall();
            public void setMeeting()
            {
                videoCall.makeVideoCall();
                voiceCall.makeVoiceCall();
            }
        }

```

Şimdilik bir sorun yok gibi fakat ileride toplantı biçimleri değiştiğinde, yeni bir toplantı biçimi eklendiğinde veya kaldırıldığında ana sınıfımız olan Meeting sınıfına gidip değişiklik yapmamız gerekecek. 
Bu durum kodumuzun esnekliğini azaltacaktır. Her değişiklikte Meeting sınıfını da güncellemek durumunda kalacağız. Şu anda Meeting sınıfımız kendisini kullanan diğer sınıflara bağımlı konumdadır.
Bu durumu düzeltmek için Dependency Inversion prensibini devreye sokabiliriz. Toplantı ve toplantı biçimleri arasına bir soyut katman ekleyeceğiz.

```
        public interface IMeeting
        {
            void makeMeeting();
        }

```

IMeeting adında bir interface oluşturup içine makeMeeting adında bir metot koyuyoruz. Bu interface bizim soyutlama katmanımız. Her toplantı türü için bunu implemente edeceğiz.

```

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

```
VideoCall ve VoiceCall sınıflarını güncellediğimizde artık toplantı oluşturma tek bir yerden yönetiliyor olacak. Son olarak Meeting sınıfını güncelleyelim.

```
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

```

Meeting sınıfının son halinde interface'i tanımladık ve setMeeting metodunun içinde gönderilmiş olan toplantı türlerini dönerek toplantı oluşturma işlemini gerçeleştiriyoruz.
Bu noktada Meeting sınıfı dışarıdan hangi toplantı türlerinin gönderildiği ile ilgilenmiyor.
Aynı zamanda toplantı türü eklendiğinde de Meeting sınıfmız yani merkezi sınıfımız bundan eklenmeyecek.

Sonuç olarak Dependency Inversion kodun bağımlılığını azaltan ve kodun yeniden kullanılabilirliğini arttıran oldukça önemli bir prensiptir.


