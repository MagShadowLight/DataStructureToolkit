using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StacksQueues
{
    public class MyStack
    {
        private readonly Stack<string> _undohistory = new Stack<string>();
        private readonly Stack<string> _redohistory = new Stack<string>();
        public string Text { get; set; } = string.Empty;
        public int Count { get { return _undohistory.Count; } }

        /// <summary>
        /// AppendText: Append the new text from the previous set of text
        /// </summary>
        /// <param name="newText">The text that will be append into the result</param>
        /// <returns>The result of the appended text</returns>
        /// <remarks>O(1) amortized: It would use the stack to push the text into history</remarks>
        public void AppendText(string newText)
        {
            _undohistory.Push(Text);
            Text += newText;
        }
        /// <summary>
        /// DeleteLastChar: Deleting the last char from the text
        /// </summary>
        /// <returns>return the new text after deletion</returns>
        /// <remarks>O(1) amortized: it uses the stack pushing to push text into history</remarks>
        public void DeleteLastChar()
        {
            if (Text.Length == 0) return;
            _undohistory.Push(Text);
            Text = Text.Substring(0, Text.Length - 1);
        }

        /// <summary>
        /// Undo: Undo the last edited text and restore the previous version of text
        /// </summary>
        /// <returns>the previous version of the text history</returns>
        /// <exception cref="InvalidOperationException">If the history does not have text, It would throw error</exception>
        /// <remarks>O(1): It would uses the stack popping to get the last text from the stack out of the stack
        /// since this methods uses the push method for redo, its complexity was O(1) amortized</remarks>
        public string Undo()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty history");
            }
            _redohistory.Push(_undohistory.Peek());
            return _undohistory.Pop();
        }
        /// <summary>
        /// Redo: Redo the last edited text and restore the current version of text
        /// </summary>
        /// <returns>the current version of the text history</returns>
        /// <exception cref="InvalidOperationException">If the history does not have text, It would throw error</exception>
        /// <remarks>O(1): It would uses the stack popping to get the last text from the stack out of the stack but since it has push method of stacks, it also uses
        /// O(1) amortized</remarks>
        public string Redo()
        {
            if (_redohistory.Count == 0)
            {
                throw new InvalidOperationException("Empty history");
            }
            _undohistory.Push(_redohistory.Peek());
            return _redohistory.Pop();
        }

        /// <summary>
        /// PeekHistory: Peek the last edited text without restoring the previous text
        /// </summary>
        /// <returns>the previous version of the text history</returns>
        /// <exception cref="InvalidOperationException">If history does not have the text, It would throw error</exception>
        /// <remarks>O(1): It uses the peek to get last text from the stack</remarks>
        public string PeekHistory()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty history");
            }
            return _undohistory.Peek();
        }


    }
}
