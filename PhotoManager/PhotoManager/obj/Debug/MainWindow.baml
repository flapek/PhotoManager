   M S B A M L   `   `   `  ����G  CPhotoManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PhotoManager.WorkersPhotoManager.Workers  5   	   K*clr-namespace:PhotoManager.CarouselControlPhotoManager.CarouselControl  5   	       PhotoManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3
converters"clr-namespace:PhotoManager.Workers  5   	   @CarouselControl*clr-namespace:PhotoManager.CarouselControl  5   	   -   5          �Name$  Window��5   	    � Title$ PhotoManager��5
   	   $	��450��6   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6=    � WindowStyle$
 None=�5      ��5      �� 5   
    �� EndPoint$ 0.5,0&�6    �� 
StartPoint$ 0.5,1&�6/   .��5      �  � Color$ 
WhiteSmoke��6    � Offset$ 0Q�6.   � 5      $ 	LightBlue��6   $	 0.3Q�6-   � 5      $ 	SteelBlue��6   $	 1.0Q�6-   5       � 	Resources 5         	CloseMenu	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  OpenMenu)  #PhotoManager.Workers.WidthConverter  WidthConverter�� 5   
   %I  &	        &	 
    &	     �� 5      .��5      U� $�	 {(UIElement.RenderTransform).                                            (TransformGroup.Children)[3].(TranslateTransform.X)�60   $
 GridMenu��5   ,   .\�5        $ 0:0:0.3��6+   $ 0Q�6=   5      U� 5      $	 (UIElement.Opacity)�60   $
 GridMainPanel��5   ,   .\�5        $ 0:0:0.5��6+   $ 1Q�6=   5      U� 5      $	 (UIElement.Opacity)�60   $
 GridEmptyMenu��5    ,   .\�5!        $ 0:0:0.5��6+   $ 0Q�6=   5"      5#      �� 5%      .��5&      U� $�	 {(UIElement.RenderTransform).                                            (TransformGroup.Children)[3].(TranslateTransform.X)�60   $
 GridMenu��5(   ,   .\�5)        $ 0:0:0.3��6+   $	 300Q�6=   5*      U� 5+      $	 (UIElement.Opacity)�60   $
 GridMainPanel��5,   ,   .\�5-        $ 0:0:0.5��6+   $	 0.5Q�6=   5.      U� 5/      $	 (UIElement.Opacity)�60   $
 GridEmptyMenu��50   ,   .\�51        $ 0:0:1��6+   $	 0.1Q�6;   52      53        55      6(   57       � Triggers 59      :� 5:   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonClose��66   .[�5;      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5;      #��[  6A   5<      :� 5>   
   $ Grid.MouseLeftButtonDown��6   $ GridEmptyMenu��6>   .[�5?      �� -   5        $  CloseMenu_BeginStoryboard2��5?      #��[  6B   5@      :� 5B   
   $ ButtonBase.Click��6   $ ButtonOpenMenuTab��66   .[�5C      �� #��[ 6   5D      .��5H      � .+�5I   
   � -   5         �Name$ GridMainPanel��5I       � RowDefinitions 5J      �� 5K      $��40 �6    �� 5L      $��* �6    �� 5M      $
��2.5* �6    �� 5N      $��50 �6    .+�5Q      � -   5        $��TopPanel��5Q       � ColumnDefinitions 5R      �� 5S      $��40 �6'   �� 5T      �� 5U      $
��auto �6'   .+�5X      �� -   5         ��Name$ ButtonOpenMenuTab��5X       � ToolTip$ 	Open menu��5Y   9   ��5X   4   Z� ��6J   Z� .��5Z      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$
 Menu=�6.   ���	#FF313131$��24��6Q   $��24��6\   5[      � 5]      $��2��6    5^      �� 5_      $
��auto �6(   �� 5`       5b      �� 5c      �� 5d      �� 5e      .+�5h      �� -   5        $��ButtonMinimizeWindow��5h   F     StyleNoneButton#��[ 6   $ Minimize window��5j   U   .��5k        $ WindowMinimize=�62   $��20��6H   $��20��6S   5l      �� 5n      -   5        $��ButtonMaximize��5n   F   #��[ 6   $��1��6\   $ Maximize window��5p   U   .��5q        $ WindowMaximize=�62   $��20��6H   $��20��6S   5r      �� 5t      -	   5        $��ButtonCloseWindow��5t   F   #��[ 6   $��2��6_   $ 	Close app��5v   R   .��5w        $ WindowClose=�62   $��20��6E   $��20��6P   5x      5y      5z      � 5|      -
   5        $��PanelWithInformation��5|      $��1��6/    5}      �� 5~      $	��100 �6'   �� 5      �� 5�      $	��100 �6'   .+�5�      � $��1��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $��32(�6X   $��Champagne & Limousines)�5�      
�������$��Center=�6W   $��10q�5�      $��Center=�6(   ��5�   )   �� *SelectedFolderOrImage.Name+5�   (   �� 5�      $��2��6    $��16(�6`   $��Champagne & Limousines)�5�       
�������$	��Top=�6[   $��5q�5�       $��Center=�6+   ��5�   -   �� *#!SelectedFolderOrImage.Description+5�   +   5�      5�      � 5�      -   5        $��PanelCarousel��5�      $��2��6(   .+�5�      2   ,PhotoManager.CarouselControl.CarouselControl  -   5          Name$ CarouselFolderOrImage��5�   2      ShowRotation .    TiltInDegrees$ 10Q�5�   F      AutoSizeToParent .    RotationSpeed$	 100Q�5�   J      VerticalOrientation .  $��Stretch=�5�   N   $��Stretch=�5�   2      ItemsSource 5�   2   �� *FolderOrImageDAB+ �� UpdateSourceTrigger$ PropertyChanged=�   SelectedItem 5�   2   �� *SelectedFolderOrImage+  �� Mode$  TwoWay=���5�      �� 5�      ! �� 
TargetType"!  6    .�5�      �� " �� Property" �@ CarouselItemTemplate# �� Value# 5�   "   �� 5�   &   .R�5�   *   �� $��1q�61   
�������
�����F���5�   1   �� $ �� ElementName$$ Window��% �� Path$% Width�& �� 	Converter#& [ ' �� ConverterParameter$' 20����5�   1   �� $$ Window��$% Width�#& [ $' 12��._�5�   .   �  5�   2   �� 5�   6   $��* �6D   �� 5�   6   $��26 �6D   .+�5�   2   �� $��0��69   $��0q�6F   
�������._�5�   6   �� $��0��6<   $��Uniform=�5�   <   $��5q�6N   ��5�   I   �� *ImageSource+5�   N   5�   3   �� 5�   2   $��1��68   
�������
������ $��18(�5�   8   $��Arial)�6F     LabelStyleCentred#��[ 5�   8   $��Bottom=�5�   8   ��5�   E   �� *Name+5�   8   5�   /   5�   +   5�   '   5�      5�      5�      5�      � 5�      $��3��6    5�      �� 5�      �� 5�      �� 5�      .+�5�      �� -   5        $��_checkBoxVerticalCarousel��5�      $��Vertical View��6<     BaseStyleCheckBox#��[ 5�      $
��50 0q�6F   ( d� 	IsChecked( 5�      �� *VerticalCarousel+5�   F   � 5�      $��2��6    5�      �� 5�      $
��Auto �6+   �� 5�      �� 5�      �� 5�      .+�5�      �� -   5        $��
ButtonBack��5�      $ Previous photo/folder��6/   #��[ 5�      .��5�        $ 	ArrowBack=�62   ���	#FF313131$��40��6Z   $��40��5�   2   5�      �� 5�      $
��Back��6   $��1��6+     BaseStyleLabel#��[ 5�      $
��Left=�6D   �� 5�      -   5        $��
ButtonNext��5�      $ Previous photo/folder��6/   $��2��6O   #��[ 5�      .��5�        $ 
FolderOpen=�62   ���	#FF313131$��40��6[   $��40��5�   2   5�      5�      5�      5�      � 5�   
   -   5        $ GridMenu��5�      $
��Left=�5�      $��
-300 0 0 0q�6*   ) J� RenderTransformOrigin$) 0.5,0.5&�6>   ��5�   !   �� $$ Window��$% ActualWidth� 5�      �� 5�      $	��300 �6#   �� 5�       5�      �� 5�      $	��120 �6    �� 5�      z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      .+�5�      �� $f��`C:\Users\filap\source\repos\PhotoManager\PhotoManager\PhotoManager\Picture\MenuTabBackground.jpg��6   $��UniformToFill=�5�   $   $	��120��6<   �� 5�      -   5        $ ButtonClose��5�      $��Right=�6*   $	��Top=�6F   #��[ 5�      
�������$��30��6Q   $��30��6\   $��0q�5�      $ 
Close menu��6!   .��5�        $ Close=�6*   $��20��67   $��20��6B   5�      � 5      -   5        $ BaseMainMenuPanel��5   3   
�������$��1��6&   .+�5     � -   5        $ MainMenuPanel��5     .+�5     �� .+�5     ��   DefaultStyle#��[ 6#   .@�5     �� -   5        * ��Name$* ListViewItemFolder��5  C   $��45��6+   $��0q�67   $ Add/Delete/Edit��5  +   .��5	  "   ��   StackPanelHorizontal#��[ 6-   .+�5
  &     $ CreateNewFolder=�6>    	 SizeOfMaterialIcon#��[	 6U   
��� � �5  :   �� 5  &   $��Folder��60    
 MenuOptionText#��[
 6>   5  #   5     �� 5     -   5        $* ListViewItemPhoto��5  C   $��45��6+   $��0q�67   $ Add/Delete/Edit��5  +   .��5  "   �� #��[ 6-   .+�5  &     $ InsertPhoto=�6>   #��[	 6Q   ���	#FFF080335  :   �� 5  &   $��Photo��60   #��[
 6=   5  #   5     �� 5     -   5        $* ListViewItemTag��5  C   $��45��6+   $��0q�67   $ Add/Delete/Edit��5  +   .��5  "   �� #��[ 6-   .+�5  &     $	 Tag=�6>   #��[	 6I   ���	#FFE6A7015  :   �� 5  &   $	��Tag��60   #��[
 6;   5  #   5      �� 5!     -   5        $* ListViewItemEditPhoto��5!  C   $��45��6+   $��0q�67   $ Edit photo in editor��5#  +   .��5$  "   �� #��[ 6-   .+�5%  &     $
 Edit=�6>   #��[	 6J   
�������5&  :   �� 5'  &   $��
Edit photo��60   #��[
 6B   5(  #   5)     �� 5*     -   5        $* ListViewItemSettings��5*  C   $��45��6+   $��0q�67   $ Settings��5,  +   .��5-  "   �� #��[ 6-   .+�5.  &     $ Settings=�6>   #��[	 6N   ���	#FF0069C15/  :   �� 50  &   $��Settings��60   #��[
 6@   51  #   52     �� 53     -   5        $* ListViewItemCloseApp��53  C   $��45��6+   $��0q�67   $ 	Close app��55  +   .��56  "   �� #��[ 6-   .+�57  &     $ WindowClose=�6>   #��[	 6Q   ���	#FFD4151558  :   �� 59  &   $��	Close app��60   #��[
 6A   5:  #   5;     5<     5=     5>     5?     � 5A     -   5        $ GridEmptyMenu��5A     $��1��6*   $��2��6:   
�������+ J� Opacity$+ 0Q�6b   $y�Hidden=�5B     5C     5D     5E     5F     