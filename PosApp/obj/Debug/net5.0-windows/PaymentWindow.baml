   M S B A M L   `   `   `  ����A  =PosApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PosAppPosApp  5   	       PosApp.PaymentWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PosApp     5   	     � Title$  PaymentWindow��5   	   $	��450��6   $	��550��6,    � WindowStartupLocation$ CenterScreen=�68   $��Bahnschrift)�6]   .��5	      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��2��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF07B3F��6   � 5      $ White��6    � Offset$ 1Q�6-   5      5      �� 5    
   $��10q�6   $��2��6    $��Payment��64   $��Center=�6C   $
��Bold"�6`   $��26(�6r   ]� 5"   
   $��1��6   $��2��6!   $��
50,30,50,0q�65   .+�5#      �� $��0��6   $��
Pay Amount��6(   $��10,10q�6:   $��20(�6I   �� 5$      -   5        $��TbAmount��5$   �   $��Right=�6    �� TextAlignment$ Right=�6-   $��24(�6C   $��10q�6Q   $��40��6]   $��Center=�6i   6�   5%      ]� 5&   
   $��2��6   $��2��6!   $��50,10q�65   .+�5'      �� $��0��6   $��Total��6(   $��10,10q�65   $��24(�6D   �� 5(      -   5        $��TbTotal��5(   �   $��Right=�6   	 �� TextAlignment$	 Right=�6/   $	��Rp0��6E   $��24(�6P   $��10q�6^   $��Center=�6j   6�   5)      ]� 5+   
   $��3��6   $��2��6!   ���	#FFFFD3BC$
��50,0q�6L   .+�5,      �� $��0��6   $��Change��6(   $��10,10q�66   $��20(�6E   �� 5-      -   5        $��TbChange��5-   �   $��Right=�6   $	 Right=�6/   $	��Rp0��6E   $��32(�6P   $��10q�6^   $��Center=�6j   6�   5.      �� 50   
   $��2��6   $��4��6)   
 �� Orientation$
 
Horizontal=�66   $��Center=�6O   $��Center=�6l   .+�51      �� -   5        $��btnCash��51   �   $	��Pay��6   $��50��6#   $	��120��6/   $��16(�6;   $��20,30q�6I      ButtonRounded#���   6X   
�������6�   �� 52      -   5        $��btnPrint��52   �   $��Print��6   $��50��6%   $	��120��61   $��16(�6=   $��10q�6K   #���   6W   
�������6�   53      54      55      