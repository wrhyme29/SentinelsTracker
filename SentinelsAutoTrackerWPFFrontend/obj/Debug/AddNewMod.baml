   M S B A M L   `   `   `  ����Z  VSentinelsAutoTrackerWPFFrontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SentinelsAutoTrackerWPFFrontendSentinelsAutoTrackerWPFFrontend  5   	   /    )SentinelsAutoTrackerWPFFrontend.AddNewMod   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:SentinelsAutoTrackerWPFFrontend     5   	     � Title$  	AddNewMod��5   	   $	��300��6   $	��400��6(   .��5	      � $��	15,0,15,0q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   Name:68   �� 5   
   -   5        $��tbNameField��5   /   $��0��6   $��1��6   $��Stretch=�6B   $	��200��6g   $��14,0,0,0q�6s   �� 5   
   $��Center=�6   $��1��6/   $��0��6<   	Mod Type:6W   �� 5   
   -   5        $��
cbModTypes��5      $	��200��6%   $��1��61   $��1��6>   $��
10,10,0,10q�6N   �� 5   
   $��2��6   $��0��6!   	Amount:6:   �� 5   
   -   5        $��tbAmountField��5   /   $��2��6   $��1��6   $��Stretch=�6D   $	��200��6i   $��14,0,0,0q�6u   �� 5   
   $��3��6   $��0��6!   Damage Type:6?   �� 5   
   -   5        $��cbDamageTypeList��5   0   $��3��6   $��1��6    $	��200��6H   $��
10,10,0,10q�6T   �� 5    
   $��4��6   $��0��6!   Description:6?   �� 5!   
   -   5        $��tbDescriptionField��5!   /   $��4��6   $��1��6   $	��200��6I   $��	14,0,5,10q�6U   �� 5"   
   $��5��6   $��0��6!   One Time Only?:6B   �� 5#   
   -   5        $��	cbOneTime��5#   0   $��5��6   $��1��6    $	��200��6A   $��
10,10,0,10q�6M   .@�5$      �� $
��True��6   �� 5%       �� 
IsSelected . $��False��6-   5&      �� 5'   
   $��6��6   $��0��6!   	Apply to:6<   �� 5)   
   -   5        $��cbApplyChoices��5)   0   $��6��6   $��1��6    $	��200��6F   $��
10,10,0,10q�6R   �� 5+   
   -   5        $��7��5+   ,   $	��100��69   $��10,0,0,0q�6E   .��6W   Submit6_   �� 5,   
   -	   5        $��tb_SubmitErrorMessage��5,   1   $��7��6   $��1��6!   
���  ��6N   5-      5.      