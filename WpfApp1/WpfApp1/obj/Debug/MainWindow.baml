   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  Rendelés Kezelő��5   	   $
��1080��6!   $
��1920��6/    � SizeToContent$ Manual=�6<    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�6!   ���#F5E8D0.��5      � -   5         � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $	��398 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	datagrid2��5         AutoGenerateColumns .     HeadersVisibility$ Column=�5      $��20(�5      	   CanUserAddRows	 .  
   CanUserResizeColumns
 .     CanUserSortColumns .     CanUserReorderColumns .     
IsReadOnly .    SelectionUnit$ FullRow=�5   %   ���#ffcea8���#6D4C41$��1q�5   >      GridLinesVisibility$	 All=�5         MinRowHeight$ 50Q�6-   $
��Bold"�6?   $��1��5      $��0��6     � 	Resources 5!      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow��%�  '        '  3    �� 5"      "  6   .�5#      ��  � �� �#8B5A2B63   �� 5$       � ��
 �����63   �� 5%       � ��$
 Bold"�63   �� 5&       � ��$ Center=�6C   �� 5'       � ��$ 10q�60   �� 5(       � �� �#6D4C4164   �� 5)       � ��$ 1q�68   5*      �� 5+      "  6   .�5,      ��  � �� �#A0785A63   �� 5-       � ��
 �����63   5.      5/         Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$	 RID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.3* 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *UploadedOrderId+   ElementStyle 53      �� 54      " ��6    .�55      ��  �@��TextAlignment$ Center=�6>   �� 56       � ��$ Center=�6D   �� 57       � ��$ Center=�6B   �� 58       � ��$
 Wrap=�6=   59      5;        5=      $
 Idő��6%   $ * 6�    62   �� *UploadedOrderTime+ �� StringFormat$ {0:yyyy-MM-dd HH:mm:ss}�� 5>      �� 5?      " ��6    .�5@      ��  �@��TextAlignment$ Center=�6>   �� 5A       � ��$ Center=�6D   �� 5B       � ��$ Center=�6B   �� 5C       � ��$
 Wrap=�6=   5D      5F        5H      $ 	Termékek��6%   $
 1.5* 6Y    67   �� *UploadedItems+ 5I      �� 5J      " ��6    .�5K      ��  �@��TextAlignment$ Center=�6>   �� 5L       � ��$ Center=�6D   �� 5M       � ��$ Center=�6B   5N      5P        5R      $ Típus��6%   $
 0.6* 6X    64   �� *UploadedTakeway+ 5S      �� 5T      " ��6    .�5U      ��  �@��TextAlignment$ Center=�6>   �� 5V       � ��$ Center=�6D   �� 5W       � ��$ Center=�6B   5X      5Z        5\      $ Végösszeg��6%   $ * 6^    68   �� *UploadedTotalCost+ 5]      �� 5^      " ��6    .�5_      ��  �@��TextAlignment$ Center=�6>   �� 5`       � ��$ Center=�6D   �� 5a       � ��$ Center=�6B   5b      5d      5f      �� 5h   
   $��0��6   $��2��6"   $��1��63   $	��Top=�6C   $��
10,10,10,0q�5i      $	��260��6)   .+�5j      �� -   5         ��Name$ button��5j      $��Frissítés��6%   $��80��5k      $
��Bold"�6!   $��18(�63   $��0,0,0,10q�6A   ��5l      �� 5m       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5n      �  � Color$ #D2A679��6'    � Offset$	 0.0Q�67   � 5o      $ #8B5A2B��6'   $	 1.0Q�67   5p      
����������#6D4C415t      �� 5v      -   5        $ torles��5v      $��Rendelés
teljesítve��6%   $��80��5w      $
��Bold"�6!   $��18(�63   $��0,0,0,10q�6A   ��5x      �� 5y      $	 0,0&�6*   $	 1,1&�6;   .��5z      � $ #E0A96D��6'   $	 0.0Q�67   � 5{      $ #8B5A2B��6'   $	 1.0Q�67   5|      
����������#6D4C415�      �� 5�      -   5        $ felvetel��5�      $��Rendelés
felvétele��6'   $��80��5�      $
��Bold"�6!   $��18(�63   ��5�      �� 5�      $	 0,0&�6*   $	 1,1&�6;   .��5�      � $ #E0A96D��6'   $	 0.0Q�67   � 5�      $ #8B5A2B��6'   $	 1.0Q�67   5�      
����������#6D4C415�      5�      5�      5�      