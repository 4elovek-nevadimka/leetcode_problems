namespace Solutions.Simulation
{
    internal class Task_2402
    {
        // #Array #Hash Table #Sorting #Heap(Priority Queue) #Simulation

        public void Run()
        {
            // var n = 2;
            // var n = 4;
            var n = 5;
            var meetings = new[] { 
                // new[] { 0, 10 }, new[] { 1, 5 }, new[] { 2, 7 }, new[] { 3, 4 } };
                // new[] { 18, 19 }, new[] { 3, 12 }, new[] { 17, 19 }, new[] { 2, 13 }, new[] { 7, 10 } };
                // new[] { 19, 20 }, new[] { 14, 15 }, new[] { 13, 14 }, new[] { 11, 20 } };
                new[] { 40, 47 }, new[] { 7, 16 }, new[] { 27, 38 }, new[] { 16, 43 }, new[] { 38, 40 }, new[] { 2, 25 } };
            Console.WriteLine(MostBooked(n, meetings));
        }

        public int MostBooked(int n, int[][] meetings)
        {
            int[] rooms = new int[n];

            // List(start, end, room number)
            PriorityQueue<List<long>, long> occupiedRooms = new PriorityQueue<List<long>, long>(Comparer<long>.Create((x, y) => x.CompareTo(y)));

            // 1. Each meeting will take place in the free room with the lowest number.
            PriorityQueue<long, long> freeRooms = new PriorityQueue<long, long>();
            for (int i = 0; i < n; i++)
            {
                freeRooms.Enqueue(i, i);
            }

            // 3. Meetings that have an earlier original start time should be given the room
            Array.Sort(meetings, (x, y) => x[0].CompareTo(y[0]));
            long currentTime = 0;
            for (int i = 0; i < meetings.Length; i++)
            {
                int[] meeting = meetings[i];
                // Update time to meeting time if meeting time is later
                currentTime = Math.Max(meeting[0], currentTime);

                // If no meeting rooms left, go to time where earliest room will be cleared
                if (freeRooms.Count == 0)
                {
                    long earliestFreeTime = occupiedRooms.Peek()[1];
                    currentTime = Math.Max(earliestFreeTime, currentTime);
                }

                // Clear all rooms occuring at and before this time
                while (occupiedRooms.Count > 0 && occupiedRooms.Peek()[1] <= currentTime)
                {
                    long freedRoom = occupiedRooms.Dequeue()[2];
                    freeRooms.Enqueue(freedRoom, freedRoom);
                }

                // Occupy a new room, 
                // 2. Delayed meeting should have same duration
                long nextRoom = freeRooms.Dequeue();
                rooms[nextRoom] += 1;
                occupiedRooms.Enqueue(new List<long> { 
                    currentTime, currentTime + (meeting[1] - meeting[0]), nextRoom }, currentTime + (meeting[1] - meeting[0]));
            }

            // Get smallest room with largest meetings held
            int max = 0, ansRoom = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (rooms[i] >= max)
                {
                    max = rooms[i];
                    ansRoom = i;
                }
            }
            return ansRoom;
        }

        /*

        public int MostBooked(int n, int[][] meetings)
        {
            var meetingsQueue = new PriorityQueue<Meeting, int>();
            foreach (var meeting in meetings)
            {
                meetingsQueue.Enqueue(new Meeting(meeting[0], meeting[1]), meeting[0]);
            }

            var freeRoomsQueue = new PriorityQueue<Room, int>();
            for (var i = 0; i < n; i++)
            {
                freeRoomsQueue.Enqueue(new Room() { Id = i }, i);
            }

            var bookedRoomsQueue = new PriorityQueue<Room, int>();

            while (meetingsQueue.Count > 0)
            {
                var meeting = meetingsQueue.Dequeue();
                while (bookedRoomsQueue.Count > 0
                    && bookedRoomsQueue.Peek().EndTime <= meeting.Start)
                {
                    var nextRoom = bookedRoomsQueue.Dequeue();
                    freeRoomsQueue.Enqueue(nextRoom, nextRoom.Id);
                }
                if (freeRoomsQueue.Count == 0)
                {
                    var room = bookedRoomsQueue.Dequeue();
                    freeRoomsQueue.Enqueue(room, room.Id);
                    //while (bookedRoomsQueue.Count > 0
                    //    && (bookedRoomsQueue.Peek().EndTime == room.EndTime 
                    //        || bookedRoomsQueue.Peek().EndTime < meeting.Start))
                    //{
                    //    var nextRoom = bookedRoomsQueue.Dequeue();
                    //    freeRoomsQueue.Enqueue(nextRoom, nextRoom.Id);
                    //}
                }
                //if (bookedRoomsQueue.Count > 0 
                //    && meeting.Start == bookedRoomsQueue.Peek().EndTime)
                //{
                //    var room = bookedRoomsQueue.Dequeue();
                //    freeRoomsQueue.Enqueue(room, room.Id);
                //}
                var freeRoom = freeRoomsQueue.Dequeue();
                freeRoom.Book(meeting.Start, meeting.End);
                bookedRoomsQueue.Enqueue(freeRoom, freeRoom.EndTime);
            }

            var mostBooked = 
                FindMostBooked(bookedRoomsQueue, bookedRoomsQueue.Dequeue());
            mostBooked = 
                FindMostBooked(freeRoomsQueue, mostBooked);

            return mostBooked.Id;
        }

        private Room FindMostBooked(PriorityQueue<Room, int> roomsQueue, Room mostBooked)
        {
            while (roomsQueue.Count > 0)
            {
                var room = roomsQueue.Dequeue();
                if (mostBooked.HeldMeetings < room.HeldMeetings)
                {
                    mostBooked = room;
                }
                else if (mostBooked.HeldMeetings == room.HeldMeetings)
                {
                    if (mostBooked.Id > room.Id)
                        mostBooked = room;
                }
            }
            return mostBooked;
        }

        private record Meeting(int Start, int End);

        private class Room
        {
            private int _heldMeetings = 0;

            private int _endTime = 0;

            public int Id { get; init; }

            public int HeldMeetings => _heldMeetings;

            public int EndTime => _endTime;

            public void Book(int start, int end)
            {
                _heldMeetings++;
                _endTime += _endTime == 0 ? end : end - start;
            }
        }
        */
    }
}
