   M S B A M L   `   `   `  ����  ControlTemplatesDemo    ControlTemplatesDemo.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        �� 	Resources  5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray   OptionMark.Static.Background �� Color  OptionMark.Static.Border  OptionMarkFocusVisual # OptionMark.MouseOver.Background  OptionMark.MouseOver.Border  OptionMark.MouseOver.Glyph " OptionMark.Disabled.Background  OptionMark.Disabled.Border 	 OptionMark.Disabled.Glyph !
 OptionMark.Pressed.Background  OptionMark.Pressed.Border  OptionMark.Pressed.Glyph  OptionMark.Static.Glyph �� 
TargetType  SelectiveCheckBox �� 
TargetType � 	Resources  Key	 �� TargetProperty
 �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value R� KeyTime(  "System.Windows.HorizontalAlignment   Stretch R� Value&   System.Windows.VerticalAlignment   Stretch �Name � ColumnDefinitions �� Padding ��Name �� Triggers P� Property P� Value N� EnterActions  Storyboard1 �� 
TargetName��%  &	        &	 �     &	 �     &	 �     &	 �    &	 �    &	 �    &	 
    &	 -    &		 P    &	
 s    &	 �    &	 �    &	 �    &	 �    7   7  7  7  7  7  �� 5      .�5      ��  � �� 5	   	   �� 5
   
   .R�5      �� $��2q�6    . #��� ��6;   $��1��6�   $	 1 2R�6�   5      5   	   5      �� 5      $ 	#FFFFFFFF��6<   �� 5      $ 	#FF707070��68   �� 5      .�5      ��  � �� 5   	   �� 5   
   .R�5      �� $��14,0,0,0q�6    . #��� ��6B   $��1��6�   $	 1 2R�6�   5      5   	   5      �� 5      $ 	#FFF3F9FF��6?   �� 5      $ 	#FF5593FF��6;   �� 5      $ 	#FF212121��6:   �� 5      $ 	#FFE6E6E6��6>   �� 5      $ 	#FFBCBCBC��6:   �� 5       $ 	#FF707070��69   �� 5!      $ 	#FFD9ECFF��6=   �� 5"      $ 	#FF3C77DD��69   �� 5#      $ 	#FF212121��68   �� 5$      $ 	#FF212121��67   �� 5%      " ��6   .�5&      ��  �@�FocusVisualStyle8   6+   �� 5'       � ��8  6%   �� 5(       � ��8  6&   �� 5)       � ��# � ��6%   �� 5*       � ��$ 1q�6*   �� 5+       � �� 5,   	   �� 5-   
   " ��6    5.      ���� 5/      Storyboard1 .��50      �� $*	 $(Shape.Fill).(SolidColorBrush.Color)�6*   $
 	rectangle��6k   .g�51        $ 0��6"   $ 	#FFE01616��6.     52      $ 0:0:1��6"   $/ )sc#1, 0.008568126, 0.00699541, 0.00699541��62     53      $ 0:0:3��6"   $ 	#FFE20F0F��62   54      T� 55      $,	 &(FrameworkElement.HorizontalAlignment)�6+   $

 grid��6n   ..�56      i� $ 0:0:3��6%   # Z 65   57      T� 58      $*	 $(FrameworkElement.VerticalAlignment)�6+   $

 grid��6l   ..�59      i� $ 0:0:3��6%   # Z 65   5:      5;      �� 5<      Storyboard2 6   5=      .R�5>      � $
 grid��6   $
��Left=�6   $
��Auto��69   $	��Top=�6G   $
��Auto��6_    5?      �� 5@      �� 5A      .+�5C      �� $��Stretch=�6   $
��Auto��6;   $��Stretch=�6I   $
��Auto��6e   $��1��6r   �� 5D      ���	#FFB27E7E$��1q�6+   $��1��6?   $��Stretch=�6S   $
��Auto��6q   $��Stretch=�6   $
��Auto��6�   $ 1q�6�   ���	#FFBFA2A2._�5E      � $��Stretch=�6   $
��Auto��60   $��Stretch=�6>   $
��Auto��6Z   $��0q�6g    5F      �� 5G      $��* �6    �� 5H      $��* �6    �� 5I      $��* �6    .+�5K      �� $ 	rectangle��6   ���	#FFAE6060$��Stretch=�6<   $
��Auto��6Z   $��Stretch=�6h   $
��Auto��6�   $��2q�6�   ���	#FFF70C0C$��2��6�   5L      5M      5N       5O      P� 5P       �@d�	IsChecked$
 TrueY�6)    5Q      �� 5R      8�� 6   . �5T      �� $ 	rectangle��6+    � ��$ 2��6B   5U      P� 5V       �@d�	IsChecked$ FalseY�6)    5W      �� 5X      8�� 6   . �5Z      �� $ 	rectangle��6+    � ��$ 0��6B   5[      P� 5\       � �� . . �5]      �� 8   �@�FocusVisualStyle60   �� 5^       � ��$ 4,-1,0,0q�6'   5_      P� 5`       �@J�IsMouseOver . 6+   P� 5a       � {� .  6)   P� 5b       � �� . 6)   P� 5c       �@d�	IsChecked$
 trueY�6)   P� 5d       6)   Z�  �@d�	IsChecked5f      5h   	   5i      5k      5l      