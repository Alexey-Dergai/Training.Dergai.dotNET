using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson2
{
    public class GenericQueue
    {
        private int front, rear, capacity;
        private int[] queue;

        public GenericQueue(int c)
        {
            front = rear = 0;
            capacity = c;
            queue = new int[capacity];
        }

        public void queueEnqueue(int data)
        {
            if (capacity == rear)
            {
                Console.Write("\nQueue is full\n");
                return;
            }

            else
            {
                queue[rear] = data;
                rear++;
            }
            return;
        }

        public void queueDequeue()
        {
            if (front == rear)
            {
                Console.Write("\nQueue is empty\n");
                return;
            }
            else
            {
                for (int i = 0; i < rear - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }

                if (rear < capacity)
                    queue[rear] = 0;

                rear--;
            }
            return;
        }

        public void queueDisplay()
        {
            int i;
            if (front == rear)
            {
                Console.Write("\nQueue is Empty\n");
                return;
            }

            for (i = front; i < rear; i++)
            {
                Console.Write(" {0}  ", queue[i]);
            }
            return;
        }

        public void queueFront()
        {
            if (front == rear)
            {
                Console.Write("\nQueue is Empty\n");
                return;
            }
            Console.Write("\nFront Element is: {0}", queue[front]);
            return;
        }
    }
}
