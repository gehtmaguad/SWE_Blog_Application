MSE/SWE My WebServer
======================

C# Template für das Übungsbeispiel "My-MSE-Blog". Damit die Übung erfolgreich abgegeben werden kann müssen folgende Kriterien erfüllt sein:

* Die Solution muss MSE-SWE.sln heißen
* JEDE/R in der Gruppe muss in SEIN Repository hochladen (git push)

Benutzen Sie bitte die Vorlage. Sie ist so vorbereitet, dass sie am Jenkins verwendet werden kann.

> **Wichtig!** Unter **keinen** Umständen ein Update auf **MVC 5** oder höher durchführen! 
> 
> Mono 3.10 wirft eine "System.MissingMethodException" sobald ein @Html.ActionLink("Administration", "Index", "Admin") benutzt wird. Die MVC Vorlage von MonDevelop ist trügerisch, da sie auf der Hauptseite eben **keinen** ActionLink benutzt. 

### Unterstütze Entwicklungsumgebungen ###
Diese Vorlage wurde für Visual Studio 2013 sowie MonoDevelop 5.5 erstellt. Sie können aber jede andere Entwicklungsumgebung benutzen, solange MSE-SWE.sln am Jenkins kompilierbar bleibt. Sie können unter Windows oder unter Linux arbeiten.

### Linux ###
Eine Anleitung zur Installation von Mono sowie MonoDevelop finden Sie hier: 

[http://www.mono-project.com/docs/getting-started/install/linux/](http://www.mono-project.com/docs/getting-started/install/linux/)

Repository
----------
https://inf-swe-git.technikum-wien.at/

Das Repository ist vom Gruppenleiter selbst anzulegen: 

* my dashboard 
* owned 
* new repository 
* se00x000/MSE-WS??-SWE

Das Repository hat die URL: https://se00x000@inf-swe-git.technikum-wien.at/?r=~se00x000/MSE-WS??-SWE.git

* se00x000 ist durch Ihre uid-Nummer zu ersetzen
* MSE-WS??-SWE durch das Jahr (WS 2015/16 -> MSE-WS15-SWE)

Sie sollten Ihr Repository Ihren KollegInnen freigeben.

Setup des Projektes
-------------------
[https://inf-swe-git.technikum-wien.at/summary/?r=MSE/SWE.git](https://inf-swe-git.technikum-wien.at/summary/?r=MSE/SWE.git)

Clonen Sie das Template in ein Verzeichnis Ihrer Wahl und ändern Sie anschließend den remote/origin auf Ihr Repository
	
	git clone https://inf-swe-git.technikum-wien.at/r/MSE/SWE.git
	cd SWE
	git remote set-url origin https://se00x000@inf-swe-git.technikum-wien.at/r/~se00x000/MSE-WS??-SWE.git
    git push origin master

Ihr KollegeInn klonen dann Ihr Repository.

Implementierung
---------------
Im Verzeichnis "Übungen" finden Sie für jede Abgabe eine Implementierung des jeweiligen Übungsinterface. Die Dokumentation finden Sie an dem Interface selbst.

Es spielt keine Rolle, wie die Abgabe-Klassen heißen oder in welchem Namespace sie liegen. Die Unit-Tests suchen nach genau einer Klasse, die das jeweilige Übungsinterface implementiert.

Ihre eigenen Klassen, die Sie im Rahmen der Übung implementieren, müssen ebenfalls bestimmte Interfaces implementieren. Diese leiten sich von den Übungsinterfaces bzw. den Unit-Tests ab.

Unit-Tests
----------
[https://inf-swe-git.technikum-wien.at/tree/?f=MSE-SWE&r=SYSTEM/unit-tests.git&h=master](https://inf-swe-git.technikum-wien.at/tree/?f=MSE-SWE&r=SYSTEM/unit-tests.git&h=master)

Am Jenkins wird Ihre Abgabe mit diesen Unit-Tests getestet. Diese Tests stehen Ihnen zur Verfügung. Sie können daher lokal, vorab überprüfen, ob Sie die Unit-Tests bestehen oder nicht.

In diesem Projekt ist auch dokumentiert, welche Interfaces Ihre Klassen implementieren müssen um die Unit-Tests zu bestehen.

Jenkins
-------
[https://inf-swe-jenkins.technikum-wien.at/view/MSE-SWE/](https://inf-swe-jenkins.technikum-wien.at/view/MSE-SWE/)

Am Jenkins können Sie dann das Ergebnis Ihrer Abgabe sehen.

* Build aus dem Build-Verlauf auswählen
* Testergebnisse
* Konsolenausgabe

Sie dürfen so oft Sie möchten abgeben. Zu einem definierten Zeitpunkt (siehe Moodle) werden die Ergebnisse eingesammelt und ausgewertet. 
Am Ende der LV müssen alle Unit-Tests erfolgreich sein, mind. jedoch 50%. Zwischenergebnisse zählen nicht mehr. Die Anzahl der erfolgreich bestandenen Unit-Tests fließt in die Bewertung der Übung ein.