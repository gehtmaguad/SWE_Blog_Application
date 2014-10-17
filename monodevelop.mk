Installationsanleitung MonoDevelop
==================================
http://monodevelop.com/

Bitte nicht mit der Versionsnummer verwirren lassen. Die aktuelle Version (Stand 12.9.2014) ist irgendwas zwischen 5.3 und 5.6.

Windows
-------
Voraussetzung:

http://download.xamarin.com/GTKforWindows/Windows/gtk-sharp-2.12.25.msi

Danach herunterladen und installieren:

http://download.xamarin.com/studio/Windows/XamarinStudio-5.0.1.3-0.msi

Nach dem Programmstart wird ein Update auf 5.3 vorgeschlagen.

Linux
-----
https://github.com/mono/monodevelop
http://monodevelop.com/developers/building_monodevelop

Folgende Pakete müssen installiert sein:

    sudo apt-get install git
	sudo apt-get install autoconf
	sudo apt-get install mono-complete
    sudo apt-get install gtk-sharp2
    sudo apt-get install gnome-sharp2
	sudo apt-get install mono-xsp4

Diese Zertifikate müssen eingespielt sein:

    sudo mozroots --import --machine --sync
    sudo certmgr -ssl -m https://go.microsoft.com
    sudo certmgr -ssl -m https://nugetgallery.blob.core.windows.net
    sudo certmgr -ssl -m https://nuget.org

Die "Registry" will auch angelegt werden:

    sudo mkdir -p /etc/mono/registry
	sudo chmod uog-rw /etc/mono/registry
	
Repo clonen und die Version wählen:

    git clone git://github.com/mono/monodevelop.git
    git checkout monodevelop-5.6-branch

Kompilieren:

	./configure && make

Starten:

     make run	

evtl. Installieren

     make install
