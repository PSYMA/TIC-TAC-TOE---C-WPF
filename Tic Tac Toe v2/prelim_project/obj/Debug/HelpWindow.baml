   M S B A M L   `   `   `  ����I  Eprelim_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:prelim_projectprelim_project  5   	       prelim_project.HelpWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:prelim_project     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	   $	��400��5   	   $	��500��5   	   .��5      � ��5   
   �� 5       �� ImageSource$2 ,/prelim_project;component/Images/galaxy4.png��6    j� Stretch$ UniformToFill=�5       �� BitmapScalingMode$ NearestNeighbor=�5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5"   
   �� -   5         ��Name$ _informationTextBlock��5-      $��0��5"      $��0��5#      $��2��5$      $��5��5%      $�� ��5&      $
��Bold"�5'      $��Italic$�5(      $��Center=�5)      $��Center=�5*      $
��Wrap=�5+      $��16(�5,      ���	#FFE8FF005.      �� 50   
   -   5         ��Name$ _imageLabel��53      $��2��50      $��3��51      $��4��52      $��0��54      56      �� 58   
   -   5        $��2��58      $��4��59      $
��BACK��5:      $
��Bold"�5;      $��Italic$�5<      $��20(�5=      ���	#00000000
��� ���$
��0,12q�5@      $
��Left=�5A      $��62��5C      �� 5E   
   -   5        $��2��5E      $��4��5F      $
��NEXT��5G      $��2��5H      $
��Bold"�5I      $��Italic$�5J      $��20(�5K      ���	#00000000
��� ���$��74,12,59,12q�5O      �� 5Q   
   -   5        $��3��5Q      $��4��5R      $��50��5S      $��Back to Main��5T      $��2��5U      $
��Bold"�5V      $��Italic$�5W      $��20(�5X      ���	#00000000
��� ���$��50,0,0,0q�5\      5]      5^      