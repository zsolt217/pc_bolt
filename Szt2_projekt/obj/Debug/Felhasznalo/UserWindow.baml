   M S B A M L   `   `   `  ����G  CSzt2_projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Szt2_projektSzt2_projekt  5   	       Szt2_projekt.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Szt2_projekt     5   	   -   5          � Title$  
UserWindow��5   	   $	��550��6   $	��700��6)   .��5	      � .+�5
   
   �� 
�������$��0,8,0,32q�6(   .@�5      �� $��Adatok��6   .��5      � .+�5      �� -   5         ��Name$ label��5      $��Név:��6+   $
��Left=�6:   $��	87,50,0,0q�6U   $	��Top=�6h   �� 5      -   5        $ label1��5      $��Telefonszám:��6,   $
��Left=�6C   $��	87,90,0,0q�6^   $	��Top=�6q   �� 5      -   5        $ label2��5      $��Cím:��6,   $
��Left=�6;   $��
87,130,0,0q�6V   $	��Top=�6j   �� 5      -   5        $ label5_Copy��5      $��Email:��61   $
��Left=�6B   $��
87,170,0,0q�6]   $	��Top=�6q   �� 5      -   5        $ label3��5      $��Label��6,   $
��Left=�6<   $��
261,50,0,0q�6X   $	��Top=�6l   �� 5      -   5        $ label4��5      $��Label��6,   $
��Left=�6<   $��
261,90,0,0q�6W   $	��Top=�6k   �� 5      -   5        $ label5��5      $��Label��6,   $
��Left=�6<   $��261,130,0,0q�6W   $	��Top=�6l   �� 5      -	   5        $ label5_Copy1��5      $��Label��62   $
��Left=�6B   $��261,170,0,0q�6]   $	��Top=�6r   �� 5      -
   5         ��Name$ 
adatButton��5      $��Adatok módosítása��61   $	��175��6M   $��40��6Y   $��239,295,243,103q�6e   6�   5      5      �� 5      $��Konfiguráció��6   .��5      �  � ColumnDefinitions 5      �� 5      $
��285* �6+   6:   �� 5      $
��397* �6+   6:   .+�5!      �� -   5         ��Name$ cBoxAlaplap��5!      $
��Left=�64   $��	52,30,0,0q�6O   $	��Top=�6b   $	��170��6z   $��22��6�   �� 5"      -   5        $ cBoxProcesszor��5"      $
��Left=�67   $��	52,75,0,0q�6R   $	��Top=�6e   $	��170��6}   $��22��6�   �� 5#      -   5        $ cBoxVideokartya��5#      $
��Left=�68   $��
52,120,0,0q�6S   $	��Top=�6g   $	��170��6   $��22��6�   �� 5$      -   5        $ cBoxMemoria��5$      $
��Left=�64   $��
52,165,0,0q�6O   $	��Top=�6c   $	��170��6{   $��22��6�   �� 5%      -   5        $ cBoxWinchester��5%      $
��Left=�67   $��
52,210,0,0q�6R   $	��Top=�6f   $	��170��6~   $��22��6�   �� 5&      -   5        $ cBoxSSD��5&      $
��Left=�60   $��
52,255,0,0q�6K   $	��Top=�6_   $	��170��6w   $��22��6�   �� 5'      -   5        $ cBoxTapegyseg��5'      $
��Left=�66   $��
52,300,0,0q�6Q   $	��Top=�6e   $	��170��6}   $��22��6�   �� 5(      -   5        $ cBoxHaz��5(      $
��Left=�60   $��
52,345,0,0q�6K   $	��Top=�6_   $	��170��6w   $��22��6�   	� 5*      -   5         	�Name$ 	rbAlaplap��5*   "   $��Alaplap:��65   $��52,10,171,366q�6H   	� 5+      -   5        $ rbProcesszor��5+   "   $��Processzor:��68   $
��Left=�6N   $��	52,55,0,0q�6i   $	��Top=�6|   $��16��6�   $��75��6�   	� 5,      -   5        $ rbVideokartya��5,   "   $��Videókártya:��69   $
��Left=�6P   $��
52,100,0,0q�6k   $	��Top=�6   $��16��6�   $��82��6�   	� 5-      -   5        $ 	rbMemoria��5-   "   $��	Memória:��65   $
��Left=�6H   $��
52,145,0,0q�6c   $	��Top=�6w   $��16��6�   $��66��6�   	� 5.      -   5        $ rbWinchester��5.   "   $��Winchester:��68   $
��Left=�6N   $��
52,190,0,0q�6i   $	��Top=�6}   $��16��6�   $��78��6�   	� 5/      -   5        $ rbSSD��5/   "   $��SSD meghajtó:��61   $
��Left=�6I   $��
52,235,0,0q�6d   $	��Top=�6x   $��16��6�   $��94��6�   	� 50      -   5        $ rbTap��50   "   $��Tápegység:��61   $
��Left=�6F   $��
52,280,0,0q�6a   $	��Top=�6u   $��16��6�   $��76��6�   	� 51      -   5        $ rbHaz��51   "   $��Ház:��61   $
��Left=�6@   $��
52,325,0,0q�6[   $	��Top=�6o   $��16��6�   $��39��6�   �� 53      -   5        $ MegrendelésButton��53      $��Megrendelés!��68   $��24,383,171,25q�6O   $��85��6f   $��30��6q   6}   �� 54      -   5        $ MentésButton��54      $��Mentés!��63   $��160,383,35,25q�6E   $��85��6\   $��30��6g   � 55      $��1��6    58      �� 59      61   �� 5:      61    � RowDefinitions 5<      �� 5=      6.   �� 5>      6.   �� 5?      6.   �� 5@      6.   �� 5A      6.   �� 5B      6.   �� 5C      6.   .+�5F      �� $
��Ár:��6    $��0��6.   $��0��6>   $��Center=�6K   $��Right=�6m   $��10q�6�   6�   �� 5G      $��	Gyártó:��6    $��0��62   $��1��6B   $��Center=�6O   $��Right=�6q   $��10q�6�   6�   �� 5H      $��Magok száma:��6    $��0��67   $��2��6G   $��Center=�6T   $��Right=�6v   $��10q�6�   6�   �� 5I      $��	Foglalat:��6    $��0��64   $��3��6D   $��Center=�6Q   $��Right=�6s   $��10q�6�   6�   �� 5J      $��Órajel:��6    $��0��62   $��4��6B   $��Center=�6O   $��Right=�6q   $��10q�6�   6�   �� 5K      $��Fogyasztás:��6    $��0��66   $��5��6F   $��Center=�6S   $��Right=�6u   $��10q�6�   6�   5M      5N      5O      �� 5Q      $��	Kedvencek��6   .��5R      � .+�5S      �� -   5        $ kedvencMegrendelesButton��5S      $��Megrendelés!��6?   $
��Left=�6V   $��118,383,0,0q�6q   $	��Top=�6�   $	��100��6�   �� 5T      -   5        $ kedvencModositasButton��5T      $��Módosítás!��6=   $
��Left=�6R   $��475,383,0,0q�6m   $	��Top=�6�   $	��100��6�   �� 5U      -   5        $ cBoxKedvenc��5U      $
��Left=�64   $��
118,52,0,0q�6O   $	��Top=�6c   $	��457��6{   �� 5V      -    5         ��Name$ listBox��5V      $
��Left=�6/   $	��230��6J   $��
118,98,0,0q�6W   $	��Top=�6k   $	��457��6�   5X      5Z      �� 5\      $��Kapcsolatfelvétel��6   .��5]      �  5^      �� 5_      $��50 �6(   67   �� 5`      6+   �� 5a      $��50 �6(   66   .+�5c      �� $��0��6   $C��=Ha bármi kérése,vagy panasza van,azt kérem itt írja meg!��6)   $��Center=�6l   $��Center=�6�   6�   �� 5d      -!   5         ��Name$ kapcsolattBox��5d   +   $��1��6   $	��300��6B   $��5q�6O   6]   �� 5e      -"   5        $ kuldesButton��5e   *   $��2��6   $��	Küldés!��6@   $��70��6R   $��25��6]   $��157,10,445,15q�6i   6�   �� 5f      -#   5        $ megsemButton��5f   *   $��2��6   $��Mégsem!��6@   $��70��6R   $��25��6]   $��452,10,150,15q�6i   5g      5h      5j      �� 5k   
   -$   5        $ kijelentkezesButton��5k      $��Kijelentkezés��6.   $
��Left=�6F   $��	504,0,0,5q�6a   $��Bottom=�6t   $	��124��6�   �� 5l   
   $��Label1��6   $
��Left=�6!   $��418,494,0,0q�6<   $	��Top=�6Q   $��81��6i   $��20��6t   $��9(�6�   5m      5n      