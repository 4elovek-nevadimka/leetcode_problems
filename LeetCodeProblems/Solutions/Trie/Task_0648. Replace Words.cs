using System.Text;

namespace Solutions.Trie
{
    internal class Task_0648
    {
        // #Array #Hash Table #String #Trie

        public void Run()
        {
            Console.WriteLine(ReplaceWords(["cat", "bat", "rat"], "the cattle was rattled by the battery"));
        }

        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            // build prefix tree
            var root = new TrieNode();
            foreach (string rootWord in dictionary)
                Insert(root, rootWord);

            // parse the sentence
            var words = sentence.Split(' ');
            for (var i = 0; i < words.Length; i++)
                words[i] = FindRoot(root, words[i]);

            return string.Join(" ", words);
        }

        // prefix tree node
        internal class TrieNode
        {
            public Dictionary<char, TrieNode> children = [];

            public bool isEndOfWord = false;
        }

        internal string FindRoot(TrieNode root, string word)
        {
            TrieNode node = root;
            var prefix = new StringBuilder();
            foreach (var c in word)
            {
                if (!node.children.ContainsKey(c))
                    break;

                node = node.children[c];
                prefix.Append(c);
                if (node.isEndOfWord)
                    return prefix.ToString();
            }
            return word;
        }

        internal void Insert(TrieNode root, string word)
        {
            TrieNode node = root;
            foreach (var c in word)
            {
                if (!node.children.ContainsKey(c))
                    node.children[c] = new TrieNode();
                node = node.children[c];
            }
            node.isEndOfWord = true;
        }
    }
}
