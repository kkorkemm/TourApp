   M S B A M L   `   `   `  ����C  ?ToursApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToursAppToursApp  5          ToursApp.ToursPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ToursApp     5        N� Title$  	ToursPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �  � Orientation$ 
Horizontal=�6   $��Center=�5      $��10q�5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   .+�5      �� $;��5Введите название для поиска: ��6    �� TextAlignment$ Right=�5      $	��175��5      �� 5      -   5         ��Name$ TextBoxSearch��5      $	��225��5      5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      �� $+��%Выберите категорию: ��6   $ Right=�5      $	��175��5       �� 5!      -   5         ��Name$ 	ComboType��5!      $	��225��5#       �� DisplayMemberPath$ TypeName��5$      5%      �� 5&      -   5         ��Name$ CheckActual��5'      $E��?Показывать только актуальные туры��5&      $��5q�5*      5,      �� 5.   
   -   5        	 ��Name$	 ListViewTours��5/      $��1��5.      $��Center=�50      $��Disabled=�51      $��0q�52      ��53      �� 54      .R�55      � $ 
Horizontal=�6    $��Center=�69   56      ��58      �� 59      .R�5:      � $��20q�6   $	��350��6'    5;      �� 5<      $��70 �6,   �� 5=      $
��auto �6,   �� 5>      $
��auto �6,   �� 5?      $
��auto �6,   .+�5B      �� $��1��6    $	��400��5C       $��UniformToFill=�5D       $��5q�5E       $��Center=�5F       ��5G      �� 5H   "   
 �� Path$
 ImagePreview�6*    �� TargetNullValue 5I   &   ��5J   *   Resources/no photo.jpeg��5L   +   5N   #   5P      �� 5R      $
��Wrap=�5S   $   $��Center=�5T   $   $��Center=�5U   $   $ Center=�5V   $   $��24(�5W   $   $��DemiBold"�5X   $   $��5q�5Y   $   $	��340��5Z   $   ��5R   $   �� *
TourName+5Z   $   �� 5\      $��2��5]   $   $��Center=�5^   $   $��14(�5_   $   $��DemiBold"�5`   $   $��5q�5a   $   ��5\   $   �� *Price+ �� StringFormat$ {0:N2} рублей��5a   $   �� 5c      $��3��5d   $   $
��Left=�5e   $   $��5q�5f   $   $��12(�5g   $   ��5c   $   �� *
ActualText+5g   $   �� 5i      $��3��5k   $   $��Right=�5l   $   $��5q�5m   $   $��12(�5n   $   ��5j      �� *TicketCount+$* $Билетов осталось: {0}��5n   $   5p      5q      5s      5u      5v      