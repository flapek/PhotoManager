   M S B A M L   `   `   `  ����G  CPhotoManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PhotoManagerPhotoManager  5   	   ;"clr-namespace:PhotoManager.WorkersPhotoManager.Workers  5   	       PhotoManager.FolderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PhotoManager     5   	   9
converters"clr-namespace:PhotoManager.Workers     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��Window��5   .     � Title$  Folder editing��5
   	   $	��550��6    $	��900��6-   $
��1080��69   $	��720��6I    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   ��5      �� 5   
    �� EndPoint$ 0.5,0&�6    �� 
StartPoint$ 0.5,1&�6/   .��5      �  � Color$ 
WhiteSmoke��6    � Offset$ 0Q�6.   � 5      $ 	LightBlue��6   $	 0.3Q�6-   � 5      $ 	SteelBlue��6   $	 1.0Q�6-   5       � 	Resources 5      )  #PhotoManager.Workers.WidthConverter   WidthConverter�� 5   
   %   &	          5      6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   � -   5        $��TopPanel��5      	 � ColumnDefinitions	 5       �� 5!      �� 5"      $
��auto �6#   .+�5%      � .+�5&      � 
�������
 J� Opacity$	
 0.2Q�6*   �� 5'        BaseStyleLabel#��[ 6   ��5(      ��  �� ElementName$ Window�� �� Path$ Title�5)      � 5+      $��2��6    5,      �� 5-      $
��auto �6$   �� 5.      	 50      �� 51      �� 52      .+�55      � $��2��6   $��2��6+   
�������$	
 0.2Q�6O   �� 57      -   5        $��ButtonMinimizeWindow��57   B     StyleNoneButton#��[ 6   .��5:      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�6.   $��20��6D   $��20��6O   5;      �� 5=      -   5        $��ButtonCloseWindow��5=   B   #��[ 6   $��1��5>      .��5@        $ WindowClose=�6.   $��20��6A   $��20��6L   5A      5B      5C      � 5E   
   $��1��6   	 5F      �� 5G      �� 5H      $
��auto �6#   �� 5I      $��2* �6#   .+�5L      �  5M      �� 5N      �� 5O      $��60 �6$   .+�5R      R� -   5         R�Name$ 
FolderView��5R        	BaseStyle#��[ 6/   � 5T      $��1��6   	 5U      �� 5V      $
��auto �6+   �� 5W      �� 5X      .+�5[      �� -   5         ��Name$ ButtonRefresh��5[      #��[ 65    � ToolTip$ Refresh folder view��6^   .��5]        $ Refresh=�62     SizeOfMaterialIcon#��[ 6A   $��40��5^   2   $��40��6>   ���	#FF2B2A2A6I   5_      �� 5`      -   5        $ ButtonAddFolder��5`        SettingsButton#��[ 66   $��
Add folder��5a      $ Add folder to resource��62   $��1��6S   5b      �� 5c      -   5        $ ButtonDeleteFolder��5c      $��2��69   #��[ 5d      $��Delete folder��6E   $ Delete choosen folder��5e      6=   5f      5g      � 5i      $��2��6    5j      �� 5k      �� 5l      $��60 �6$   .+�5o      � 	 5p      �� 5q      �� 5r      .+�5u      �  5v      �� 5w      $��30 �6,   �� 5x      $
��auto �6,   �� 5y      �� 5z      �� 5{      $
��auto �6,   �� 5|      �� 5}      .+�5�      �� $��16(�6    $��10q�6.   #��[ 6:   $
��Name��5�       $��1��6/   �� 5�      -	   5         ��Name$ TextBoxFolderName��5�   Y   $��2��6"     BaseStyleTextBox#��[ 6/   $ Enter new folder name��5�   "   {�.  6T   �� 5�      $��16(�6    $��10q�6.   #��[ 6:   $��Parent Folder��5�       $��4��68   �� 5�      -
   5         ��Name$ ComboBoxParentFolder��5�   #   $��5��5�   #     BaseStyleComboBox#��[ 60   $ Choose new parent folder��5�   A   {�.  5�   #   5�      � 5�      $��1��6   .+�5�      �� -   5         ��Name$" RichTextBoxFolderDescription��5�   &     BaseStyleRichTextBox#��[ 6L   {�.  5�   8   5�      5�      � 5�      $��1��6   	 5�      �� 5�      $��2* �6+   �� 5�      �� 5�      .+�5�      �� -   5         ��Name$ CheckBoxCanEdit��5�      $��Edit folder��68    	 BaseStyleCheckBox#��[	 5�      5�      �� 5�      -   5        $ ButtonSaveChanges��5�      $��1��68   $
��Save��6H    +
 'SettingsButtonSaveSettingsIsEnableFalse#��[
 5�      $ Save changes��5�      �� 5�      -   5        $ ButtonCancelChanges��5�      $��2��6:   $��Cancel��6J   #��[ 5�      $ Cancel changes��6E   5�      5�      5�      5�      5�      5�      