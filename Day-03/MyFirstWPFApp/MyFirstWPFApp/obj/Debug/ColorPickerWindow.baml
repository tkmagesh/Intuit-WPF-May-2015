   M S B A M L   `   `   `  ����H  DMyFirstWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyFirstWPFAppMyFirstWPFApp  5   	   %    MyFirstWPFApp.ColorPickerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -myAppclr-namespace:MyFirstWPFApp     5   	   $��26(�5   	     � Title$  ColorPickerWindow��5   	   $	��300��6#   $	��450��60   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5	      $��3* �6   6,   �� 5
      $��2* �6   6,   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      6"   �� 5      6"   �� 5      6"   .+�5      �� $��0��6   .+�5      �� $��Red :��6   6+   ]� 5      ��. .+�5      �� 
���  ��$��Right=�6d   $��Center=�6{   ��6    ��  �� ElementName$ 	SliderRed�� �� Path$ Value�6�   �� 5      -   5        $��	SliderRed��5       � SmallChange$ 1Q�6.    � LargeChange$ 1Q�6>    �� IsSnapToTickEnabled .  � Minimum$ 0Q�6i   	 � Maximum$		 255Q�6u   $
��Left=�6�   $��Center=�6�   6�   5      5      �� 5      $��1��6   .+�5      �� $��Green :��6   6-   ]� 5      ��. .+�5      �� 
��� � �$��Right=�6i   $��Center=�6�   ��6!   �� $ SliderGreen��$ Value�6�   �� 5      -   5        $��SliderGreen��5      $ 1Q�60   $ 1Q�6@    . $ 0Q�6k   $		 255Q�6w   $
��Left=�6�   $��Center=�6�   6�   5      5       �� 5!      $��2��6   .+�5"      �� $��Blue :��6   6,   ]� 5#      ��. .+�5$      �� 
����  �$��Right=�6g   $��Center=�6~   ��6!   �� $ 
SliderBlue��$ Value�6�   �� 5%      -   5        $��
SliderBlue��5%      $ 1Q�6/   $ 1Q�6?    . $ 0Q�6j   $		 255Q�6v   $
��Left=�6�   $��Center=�6�   6�   5&      5'      5(      �� 5)   
   $��1��6   $��10q�6!   
 �� CornerRadius$
 10��6-   $��2q�6?   
���   � � 	Resources 5*      *   $MyFirstWPFApp.ValuesToBrushConverter   valuesToBrushConverter��%   &	          5+      6P   5,      ��5-      `� 5.       `� 	Converter# [  6   .1�5/      �� $ 	SliderRed��6   $ Value�66   6E   �� 50      $ SliderGreen��6   $ Value�68   6G   �� 51      $ 
SliderBlue��6   $ Value�67   6F   52      54      55      56      