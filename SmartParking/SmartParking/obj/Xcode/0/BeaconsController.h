// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface BeaconsController : NSViewController {
	NSButton *_Car1;
	NSButton *_Car2;
	NSButton *_Car3;
	NSTextField *_error;
	NSComboBox *_menu;
	NSComboBox *_Name;
	NSBox *_Selection;
}

@property (nonatomic, retain) IBOutlet NSButton *Car1;

@property (nonatomic, retain) IBOutlet NSButton *Car2;

@property (nonatomic, retain) IBOutlet NSButton *Car3;

@property (nonatomic, retain) IBOutlet NSTextField *error;

@property (nonatomic, retain) IBOutlet NSComboBox *menu;

@property (nonatomic, retain) IBOutlet NSComboBox *Name;

@property (nonatomic, retain) IBOutlet NSBox *Selection;

- (IBAction)Button1:(id)sender;

- (IBAction)Button2:(id)sender;

- (IBAction)Button3:(id)sender;

- (IBAction)menuAction:(id)sender;

- (IBAction)Save:(id)sender;

@end
