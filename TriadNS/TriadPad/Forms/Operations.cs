using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Общеупотребительные действия с элементами на форме
    /// </summary>
    static class Operations
        {
        /// <summary>
        /// Выделить строчку в списке
        /// </summary>
        /// <param name="listView">Список</param>
        /// <param name="indexToSelect">Индекс выдеялемого элемента</param>
        public static void SelectListViewItem( ListView listView, int indexToSelect )
            {
            if ( 0 <= indexToSelect && indexToSelect < listView.Items.Count )
                {
                listView.SelectedIndices.Clear();
                listView.Items[ indexToSelect ].Selected = true;
                listView.Items[ indexToSelect ].EnsureVisible();
                }
            }


        /// <summary>
        /// Делегат функции создания элементов списка
        /// </summary>
        /// <typeparam domainName="T">Тип вставляемых элементов</typeparam>
        /// <param name="item">Вставляемый элемент</param>
        /// <returns>Элемент списка</returns>
        public delegate ListViewItem ListViewItemConstructor<T>( T item );


        /// <summary>
        /// Заполнить список атрибутами элементов
        /// </summary>
        /// <typeparam domainName="T">Тип всталяемых элементов</typeparam>
        /// <param name="listView">Контрол отображения</param>
        /// <param name="enumerator">Счетчик элементов</param>
        /// <param name="constuctor">Конструктор элементов списка</param>
        public static void FillSpecialList<T>( ListView listView, IEnumerator<T> enumerator, ListViewItemConstructor<T> constuctor )
            {
            int selectedIndex = 0;
            if ( listView.SelectedIndices.Count != 0 )
                if ( listView.SelectedIndices[ 0 ] != -1 )
                    selectedIndex = listView.SelectedIndices[ 0 ];

            listView.Items.Clear();

            if ( enumerator == null )
                return;

            while ( enumerator.MoveNext() )
                {
                listView.Items.Add( constuctor( enumerator.Current ) );
                }

            if ( selectedIndex < listView.Items.Count )
                {
                listView.SelectedIndices.Add( selectedIndex );
                listView.EnsureVisible( selectedIndex );
                }
            else if ( listView.Items.Count != 0 )
                {
                listView.SelectedIndices.Add( 0 );
                listView.EnsureVisible( 0 );
                }
            }
        }
    }
