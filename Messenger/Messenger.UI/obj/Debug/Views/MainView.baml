   M S B A M L   `   `   `  ����G  CMessenger.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Messenger.UIMessenger.UI  5   	   A%clr-namespace:Messenger.UI.ViewModelsMessenger.UI.ViewModels  5   	   A%clr-namespace:Messenger.UI.ConvertersMessenger.UI.Converters  5	   	       Messenger.UI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Messenger.UI     5   	   4vm%clr-namespace:Messenger.UI.ViewModels     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a5beh+http://schemas.microsoft.com/xaml/behaviors  5   	   6
converters%clr-namespace:Messenger.UI.Converters  5	   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � AllowsTransparency  .  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � DataContext 5   
   ��   	vmLocator �� Source# [  �� Path$ MainViewModel� � 	Resources 5      <   6Messenger.UI.Converters.ConvertTextToFirstLatterOfText " convertTextToFirstLatterOfText��%   &	         5   
   64   5      .��5       � 	 � RowDefinitions	 5"   
   �� 5#      $��20 �6   �� 5$      .+�5&   
   � -   5        
�������$��0��5&   !   .+�5'      �� 
 �� Orientation$
 
Horizontal=�6   $��Right=�62   .+�5(      �� -   5        $
��Auto��5(      
������ 
������   MaterialDesignIconButton#���  5*      ��5)      0  *MaterialDesignThemes.Wpf.PackIconExtension  *WindowMinimize+5,      �� 5.      -   5        $
��Auto��5.      
������ 
������ #���  5/      ��51        *
DockWindow+52      �� 54      -   5        $
��Auto��54      
������ 
������ #���  56      ��55        *Close+58      5;      5<      � 5=   
   $��1��6    � ColumnDefinitions 5>      �� 5?      $��48 �6#   �� 5@      $	��35* �6#   �� 5A      $	��65* �6#   .+�5C      � $��0��6   .+�5D      �� $
 Vertical=�6   $	��Top=�65   .+�5E      �� #���  5F       � ToolTip$ 
My account��5G      .��5H      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountCircleOutline=�5I   "   $��35��6?   $��40��6K   5J      �� 5K      #���  5L      $ Create group��5M      ��5N      �� *CreateChatCommand+.��5P        $ AccountMultipleOutline=�5Q      $��35��6;   $��40��6G   5R      �� 5S      #���  5T      $ Add contact��5U      ��61   �� *AddContactCommand+.��5V        $ AccountOutline=�5W      $��35��63   $��40��6?   5X      �� 5Y      #���  5Z      $ Settings��5[      .��5\        $ 
CogOutline=�5]      $��35��6/   $��40��6;   5^      �� 5_      #���  5`      $ 	Dark mode��5a      .��5b        $ WeatherNight=�5c      $��35��61   $��40��6=   5d      5e      5f      �� 5g      $��1��5h       �� SelectedIndex$ 0��5i   	   ��5j      �� *	UserChats+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 5k      �� *SelectedChat+��5n      �� 5p      .R�5r      ��  ��Name$ Border��5s       �� Padding$ 8q�5t      $��0 0 0 1q�5u        MaterialDesignDivider#���  5x      ��5v      ��  �� RelativeSource ��  �� AncestorType$ ListBoxL�$ Width�._�5y      �  5z   "   �� 5{   &    z� SharedSizeGroup$ Checkerz��5|   (   �� 5}   &   .+�5   "   d� $��Center=�5�       ) %MaterialDesignActionLightToggleButton#��[ 5�      ��5�      �� *	Chat.Name+ �� 	Converter# [  d� 	IsChecked 5�   %   ��  �� $ ListBoxItemL� �� Mode$ FindAncestor=�$ 
IsSelected�5�   #   �� 5�   "   $��8 0 0 0q�5�   ,   $��1��5�   0   .+�5�   &   �� $
��Bold"�5�   3   ��5�   &   �� *	Chat.Name+5�   3   �� 5�   &   ��5�       �� *LastMessage.Text+5�   #   5�      5�      5�      5�      � 5�      $��2��6   	 5�      �� 5�      $��45 �6$   5�      �� 5�      $��* �6$   5�      �� 5�      $��30 �6$   5�      .+�5�      �  5�      �� 5�      $	��35* �6+   5�      �� 5�      $	��70* �6+   5�      �� 5�      $��40 �6+   5�      .+�5�      �� $��0��6!   $
 
Horizontal=�61   .+�5�      d� $��Center=�5�       * &MaterialDesignActionAccentToggleButton#��[ 5�      $ FalseY�5�      $��0,5,0,4q�6(   ��5�      �� *SelectedChat.Chat.Name+# [ 5�   (   �� 5�      $
 Vertical=�6%   .+�5�      �� $��	10,15,0,5q�6(   $��13(�6c   ��6;   �� *SelectedChat.Chat.Name+5�      5�      5�      5�      �� 5�      -   5         ��Name$ MessagesListBox��5�      $��1��64   ��6A   �� *SelectedChat.Messages+��5�      �� 5�      .R�5�      �� $
 
Horizontal=�6)   $	��300��6C   .+�5�   "   d� $��Bottom=�5�   *   $��Right=�5�   *   $��30��5�   *   #��[ 5�   *   ��5�   *   �� *Sender.User.Name+# [  5�   *   ��  �� $ ListBoxItemL�$ FindAncestor=�$ 
IsSelected�$ TwoWay=�� 5�   "   $��Right=�6'   .+�5�   "   � $��Bottom=�6*    � Points �    �  -1 �  -1 K� ZIndex$ 0��6^    	 PrimaryHueDarkBrush#��� 	 6o   6�   #  MaterialDesignThemes.Wpf.Card  5�   "   $��14,0,0,0q�5�   %   $ 10��5�   %   #��� 	 5�   %    !
 PrimaryHueDarkForegroundBrush#��� 
 5�   %   $	��200��5�   %      UniformCornerRadius$ 8Q�5�   %   $��0q�5�   %   .��5�   &   �� $��10q�5�   %   $
��Wrap=�5�   %   ��5�   %   �� *Message.Text+5�   #   5�   #   5�      5�      5�      � 5�      $��2��6    5�      �� 5      $��* �6+   5     �� 5     $	��100 �6+   5     .+�5     �� $��0��5	      �� TextWrapping$
 Wrap=�5
     $��Stretch=�5     $	��280��5      �� AcceptsReturn . "  �� VerticalScrollBarVisibility$
  Auto=�5     ! �� 	IsEnabled! . )  #MaterialDesignThemes.Wpf.HintAssist"   Hint$" Your message��5     $
��Auto��5     ��5     �� * SelectedChat.DraftMessage.Text+�� 5     $��1��6"   $
 
Horizontal=�62   $��Right=�6K   .+�5     �� #���  5     $ Voice message��5     $
��Auto��63   $��32��6A   .��5       $ MicrophoneOutline=�5     5     �� 5     #���  5     $
 Send��5     $
��Auto��5     $��26��6,   ��67   �� *SendMessageCommand+.��5        $
 Send=�5!     
����ح�6(   5"     5#     5$     5'     5)     5*     5.     