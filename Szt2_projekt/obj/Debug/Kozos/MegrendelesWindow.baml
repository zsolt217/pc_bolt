   M S B A M L   `   `   `  ����G  CSzt2_projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Szt2_projektSzt2_projekt  5   	   $    Szt2_projekt.MegrendelesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Szt2_projekt     5   	     � Title$  MegrendelesWindow��5   	   $	��500��6#   $	��500��60   .��5	      � -   5         �Name$ megrendelesGrid��5	       � RowDefinitions 5
   
   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ Alaplap��5   A   $��
-63,0,63,0q�6   $��0��6$   $��1��64   $��Alaplap:��6R   $��Right=�6e   $��Center=�6�   6�   �� 5   
   -   5        $ 
Processzor��5   A   $��
-63,0,63,0q�6   $��0��6$   $��2��64   $��Processzor::��6U   $��Right=�6l   $��Center=�6�   6�   �� 5   
   -   5        $ Videokartya��5   A   $��
-63,0,63,0q�6   $��0��6$   $��3��64   $��Videókartya:��6V   $��Right=�6m   $��Center=�6�   6�   �� 5   
   -   5        $ Memoria��5   A   $��
-63,0,63,0q�6   $��0��6$   $��4��64   $��	Memória:��6R   $��Right=�6e   $��Center=�6�   6�   �� 5   
   -   5        $ 
Winchester��5   A   $��
-63,0,63,0q�6   $��0��6$   $��5��64   $��Winchester:��6U   $��Right=�6k   $��Center=�6�   6�   �� 5    
   -   5        $ SSDmeghajtó��5    A   $��
-63,0,63,0q�6   $��0��6$   $��6��64   $��SSD meghajtó:��6V   $��Right=�6n   $��Center=�6�   6�   �� 5!   
   -   5        $ Tápegység��5!   A   $��
-63,0,63,0q�6   $��0��6$   $��7��64   $��Tápegyég:��6T   $��Right=�6h   $��Center=�6�   6�   �� 5"   
   -	   5        $
 Ház��5"   A   $��
-63,0,63,0q�6   $��0��6$   $��8��64   $��Ház:��6N   $��Right=�6]   $��Center=�6�   6�   �� 5#   
   -
   5        $ Összár��5#   A   $��
-63,0,63,0q�6   $��0��6$   $��9��64   $��Összesített ár:��6Q   $��Right=�6k   $��Center=�6�   6�   �� 5%   
   -   5        $ labelAlaplapMegrendeles��5%   1   $��
183,3,63,2q�6   $��1��6$   $��labelAlaplapMegrendeles:��6R   $��Center=�6u   $��Center=�6�   $��2��6�   �� 5&   
   -   5        $ labelProcesszorMegrendele��5&   1   $��
183,0,63,0q�6   $��2��6$   $!��labelProcesszorMegrendeles:��6T   $��Center=�6z   $��Center=�6�   $��2��6�   �� 5'   
   -   5        $! labelVideokartyaMegrendeles��5'   1   $��
183,0,63,0q�6   $��3��6$   $"��labelVideokartyaMegrendeles:��6V   $��Center=�6}   $��Center=�6�   $��2��6�   �� 5(   
   -   5        $ labelMemoriameMegrendeles��5(   1   $��
183,0,63,0q�6   $��4��6$   $ ��labelMemoriameMegrendeles:��6T   $��Center=�6y   $��Center=�6�   $��2��6�   �� 5)   
   -   5        $  labelWinchesterMegrendeles��5)   1   $��
183,0,63,0q�6   $��5��6$   $!��labelWinchesterMegrendeles:��6U   $��Center=�6{   $��Center=�6�   $��2��6�   �� 5*   
   -   5        $ labelSSDmegrendeles��5*   1   $��
183,0,63,0q�6   $��6��6$   $��labelSSDmegrendeles:��6N   $��Center=�6m   $��Center=�6�   $��2��6�   �� 5+   
   -   5        $ labelTapegysemMegrendeles��5+   1   $��
183,0,63,0q�6   $��7��6$   $ ��labelTapegysemMegrendeles:��6T   $��Center=�6y   $��Center=�6�   $��2��6�   �� 5,   
   -   5        $ labelHazmegrendeles��5,   1   $��
183,0,63,0q�6   $��8��6$   $��labelHazmegrendeles:��6N   $��Center=�6m   $��Center=�6�   $��2��6�   �� 5-   
   -   5        $ labelOsszar��5-   1   $��
183,0,63,0q�6   $��9��6$   $��labelOsszar:��6F   $��Center=�6]   $��Center=�6�   $��2��6�   �� 5/   
   -   5        $��0��5/      $��9��6!   $��Tovább��6.   $��
0,71,0,-71q�6?   $	��150��6S   6v   �� 50   
   $��1��6   $��9��6!   $��Mégse��6.   $��
0,71,0,-71q�6>   $	��150��6R   6`   51      52      