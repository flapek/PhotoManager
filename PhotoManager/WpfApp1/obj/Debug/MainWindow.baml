   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5
         MyTabItemControlTemplate �� 
TargetType   WpfApp1.MyTabItem �� Orientation   DeleteCommand �� 
TargetType �� Property �� Value��%�  &	        '  �     �� 5   
   "  6;   .R�5      �� $ 
Horizontal=�6   
������$��3q�6J   .+�5      �� #��z��6#   $��Center=�6F   $��2q�6a   �� 5      $��Delete��6   #��z 6*   $��2q�6T   5      5      �� 5   
   "  6   .�5      ��  � ��# �   6)   �� 5       �@ DeleteCommand 6.   �� *MyDeleteCommand+�� 5       � ��$ Default Header Text��6'   5      5      .��5      � .+�5   
      WpfApp1.MyTabControl  ��6   �� *MyTabItemList+5      5      