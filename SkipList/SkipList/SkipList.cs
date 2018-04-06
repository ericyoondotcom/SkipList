using System;
namespace SkipList
{
    public class SkipList<T> where T : IComparable
    {
        public SkipListNode<T> head;

        public SkipList()
        {
            head = new SkipListNode<T>(default(T), 0);    
        }


        public SkipListNode<T> AddNode(T val){
            
            var newNode = new SkipListNode<T>(val, Promote());

            if(newNode.Height > head.Height){
                head.Resize(newNode.Height);
            }

            int level = head.Height - 1;
            SkipListNode<T> node = head;
            while(level >= 0){


                if (node.next[level] == null || node.next[level].val.CompareTo(val) > 0)
                {
                    if(level + 1 <= newNode.Height){
                        newNode.next[level] = node.next[level];
                        node.next[level] = newNode;
                    }
                    level--;
                }else{
                    node = node.next[level];
                }

            }

            return newNode;

        }

        private int Promote()
        {
            Random randy = new Random(Guid.NewGuid().GetHashCode());
			int myLevel = 1;
            while (randy.Next(0, 2) == 0)
            {
                myLevel++;
            }
            return myLevel;
        }

        public SkipListNode<T> FindNode(T val){
			int level = head.Height - 1;
            SkipListNode<T> node = head;
			while (level >= 0)
			{
                if(node == null){
                    throw new Exception("Could not find node");
                }

                if(node.val.CompareTo(val) == 0 && node != head){
                    return node;
                }

				if (node.next[level] == null || node.next[level].val.CompareTo(val) > 0)
				{
					level--;
				}
				else
				{
					node = node.next[level];
				}

			}
            throw new Exception("Could not find node");
        }

        public bool Contains(T val){
			int level = head.Height - 1;
			SkipListNode<T> node = head;
			while (level >= 0)
			{
				if (node == null)
				{
                    return false;
				}

				if (node.val.CompareTo(val) == 0 && node != head)
				{
					return true;
				}

				if (node.next[level] == null || node.next[level].val.CompareTo(val) > 0)
				{
					level--;
				}
				else
				{
					node = node.next[level];
				}

			}
            return false;
        }

        public override string ToString()
        {
            string[] levels = new string[head.next.Length];

            levels[0] += "H ";
            for (int i = 1; i < levels.Length; i++){
                levels[i] += i.ToString() + " ";
            }

            SkipListNode<T> currNode = head.next[0];
            while(currNode != null){
                levels[0] += currNode.val;
                levels[0] += " ";

                for (int i = 1; i < head.next.Length; i++){
                    if(i < currNode.next.Length){
                        levels[i] += "+ ";

                    }else{
                        levels[i] += "  ";
                    }
                }
                currNode = currNode.next[0];
            }
            string final = "";
            for (int i = levels.Length - 1; i >= 0; i--){
                final += levels[i];
                final += "\n";
            }
            return final;
        }

        public void RemoveNode(T val){
            SkipListNode<T> nodeToRemove = FindNode(val);

			int level = head.Height - 1;
			SkipListNode<T> node = head;
			while (level >= 0)
			{
                if(node == nodeToRemove){
                    return;
                }

				if (node == null)
				{
					throw new Exception("AAaaaAAaAAaAAAaaa its null");
				}

                if(node.next[level] == nodeToRemove){
                    node.next[level] = nodeToRemove.next[level];
                    level--;
                    continue;
                }

				if (node.next[level] == null || node.next[level].val.CompareTo(val) > 0)
				{
					level--;
				}
				else
				{
					node = node.next[level];
				}

			}
        }


    }
}
