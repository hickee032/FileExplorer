   M S B A M L   `   `   `  ����G  CFileExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FileExplorerFileExplorer  5   	   A%clr-namespace:FileExplorer.ViewModelsFileExplorer.ViewModels  5   	       FileExplorer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FileExplorer     5   	   <
viewmodels%clr-namespace:FileExplorer.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��720��5
   	   $
��1280��6      CustomWindowStyle#���   5   	    � DataContext 5      +   %FileExplorer.ViewModels.MainViewModel  5   
   .��5      � .+�5   
   � $	��Top=�6   $��20��6'   .+�5      �� $	��Ico��6   $��Center=�6#   $��5,2,0,2q�6>   $
��Left=�6O   $��20��6j   �� 5      $��	File Name��6   $��Center=�6)   $��
29,2,410,2q�6D   �� 5      $��Date Created��6   $��Center=�6,   $��	0,2,283,2q�6G   $��Right=�6Z   $	��125��6v    �� TextAlignment$ Center=�6�   �� 5      $��Date last Modified��6   $��Center=�62   $��	0,2,156,2q�6M   $��Right=�6`   $	��125��6|   $ Center=�6�   �� 5      $
��Type��6   $��Center=�6$   $��0,2,84,2q�6?   $��Right=�6Q   $��70��6m   $ Center=�6x   �� 5      $
��Size��6   $��Center=�6$   $��0,2,7,2q�6?   $��Right=�6P   $��75��6l   $ Center=�6w   5      �� 5   
   $��Stretch=�5      $��0,20,0,0q�67   ��5      �� *	FileItems+ �� UpdateSourceTrigger$ PropertyChanged=�5   7   5      5      