# Main window

- [xaml](E_Mailer/MainWindow.xaml)
- [code](E_Mailer/MainWindow.xaml.cs)

## Structure

This window consist of two main things:
  - Window style
  - Window content

### Window style

Here is grid with border (ContentMask), which is used as OpacityMask, so all content of window stays here. Next is here deifned
CornerRadius for round edges of window and background.

- In the grid is ContentPresenter with TemplateBinding to Content (all window content defined later is here).
  > ContentPresenter must have ClipToBounds="True" for correct displaying.

- Next is here Title bar. It is grid with three buttons ( - [] X), icon and title.
  >For window moving are in title bar defined PreviewMouseMove and MouseDown (When window title bar is clicked and draged it calls 
  DragMove method which do window movement.

  >I hope to find a better solution in future.
  
### Window content
  
Here are just two things:
  - SideMenu
  - PagesFrame
