   M S B A M L   `   `   `  ����A  =Diplom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Diplom.Components.CoolingProcessor"Diplom.Components.CoolingProcessor  5   	   6    0Diplom.Components.CoolingProcessor.CoolingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:Diplom.Components.CoolingProcessor     5   	     � Title$  CoolingWindow��5      $	��650��6'   $	��850��64    � WindowStartupLocation$ CenterScreen=�5	   	   
������  � AllowsTransparency .  � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $��50 �6   .+�5   
   �� -   5         ��Name$ 	LvCooling��5      $��0��5   
   
������ $��0q�5   
   $��Disabled=�5   
   $��Hidden=�5   
   ��5      �� 5      .R�5      � 5      ��5      �� 5       .R�5!      �� ���#137868$��2q�5"      $	��220��5#      $	��440��5$      $��16q�5%       �� CornerRadius$ 8��5&      ._�5'      �  5(      �� 5)   "   $	��400 �60   �� 5*   "   .+�5,      �� $��0��6)   .+�5-   "   �� $	��280��6(   $	��220��5.      $��8q�5/      ��50   &   �� 51   *    �� Path$ 	PhotoLink�62    �� TargetNullValue 52   .   ��53   2   C?C:\Users\sanya\source\repos\ConfigPC2\ConfigPC2\Rec\noPhoto.png��6   55   +   57   #   �� 59   "   $��18(�5:   #   
���   �$	��5 3q�5<   #   $
��Wrap=�5=   #   $��DemiBold"�5>   #   ��59   ,   �� *Title+5>   #   �� 5?   "   $��18(�5@   #   
���   �$	��5 3q�5B   #   ��5?   ,   �� *Cost+	 �� ConverterCulture$	 ru_RU��
 �� StringFormat$
 {0:C0}��5B   #   �� 5C   "   $��18(�6,   
���   �$	��5 3q�5E   #   �� 5F      $�	In Stock:��6!    �� 5G      �6!   �� *	InStock+5H   #   5I      � 5J      $��Center=�6(   $��1��5K      .+�5L   "   ��  ��Name$ BtnEditCooling��6)   -   5        $��20��5M       $��20��5N       $
��Left=�5P       $��Center=�5Q       $��0q�5S       ��5O       �� *secondaryButton+��5R       Z� .��5W   &   �� $D��>C:\Users\sanya\source\repos\ConfigPC2\ConfigPC2\Rec\Redact.png��6,   5X   #   �� 5Y   "   $ BtnDelCooling��6)   -   5        $��20��5Z   $   $��20��5[   $      secondaryButton#��[  5\   $   $
��Left=�5]   $   $��10 5 0 0q�5^   $   $��0q�5`   $   ��5_   $   Z� .��5c   &   �� $E��?C:\Users\sanya\source\repos\ConfigPC2\ConfigPC2\Rec\Corzina.png��6,   5d   #   5e      �� 5f      $ BtnAdd��5g   %   -   5        $��1��5f   %   $��Right=�5h   %   $��0,0,10,0q�5i   %   $��30��5j   %   $��30��5k   %   #��[  5l   %   $��0q�5n   %   ��5m   %   Z� .��5p   "   �� $L��FC:\Users\sanya\source\repos\Diplom\Diplom\Rec\Images\Icons\addmain.png��6(   5q      5r      5s      5t      ��5v      �� 5w       �� 
TargetType" ��6   .�5x      ��  �� Property � �� �� Value
 ���� 63    �� Triggers 5y      P� 5z       P� Property �@J�IsMouseOver P� Value . . �5{      ��  � ��
 ���� 6;   5|      5~      5�      �� 5�   
    �� Orientation$ 
Horizontal=�6   $��Right=�5�      $��1��5�      .+�5�      �� -   5        $ BtnAddCooling��5�      $��Right=�5�      #��[  5�      $��0q�5�      $��	20 0 20 0q�5�      ��5�      Z� .��5�      �� $A��;C:\Users\sanya\source\repos\ConfigPC2\ConfigPC2\Rec\Add.png��6   5�      5�      5�      5�      