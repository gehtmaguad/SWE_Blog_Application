MSE/SWE My WebServer
======================

C# Template für das Übungsbeispiel "My-MSE-Blog". Damit die Übung erfolgreich abgegeben werden kann müssen folgende Kriterien erfüllt sein:

* Die Solution muss MSE-SWE.sln heißen
* JEDE/R in der Gruppe muss in SEIN Repository hochladen (git push)

Benutzen Sie bitte die Vorlage. Sie ist so vorbereitet, dass sie am Jenkins verwendet werden kann.

Diese Vorlage wurde für Visual Studio 2013 sowie MonoDevelop 5.6 erstellt. Sie können aber jede andere Entwicklungsumgebung benutzen, solange MSE-SWE.sln am Jenkins kompilierbar bleibt. Sie können unter Windows oder unter Linux arbeiten.

Eine Anleitung zur Installation von MonoDevelop finden Sie hier: https://inf-swe-git.technikum-wien.at/raw/MSE/SWE.git/master/monodevelop.pdf

Repository
----------
https://inf-swe-git.technikum-wien.at/

Das Repository ist selbst anzulegen: 

* my dashboard 
* owned 
* new repository 
* se99x000/MSE-WS??-SWE

Das Repository hat die URL: https://se99x000@inf-swe-git.technikum-wien.at/?r=~se99x000/MSE-WS??-SWE.git

* se99x000 ist durch Ihre se-Nummer zu ersetzen
* MSE-WS??-SWE durch das Jahr (WS 14/15 -> MSE-WS14-SWE)

Sie sollten Ihr Repository Ihren KollegInnen freigeben. Mit "git add remote" (http://git-scm.com/docs/git-remote) können Sie mehrere Remotes angeben und die Abgabe somit vereinfachen. Benutzen Sie hierfür das setup-remotes script.

Setup des Projektes
-------------------
https://inf-swe-git.technikum-wien.at/summary/?r=MSE/SWE.git

Laden Sie aus dem Template die Datei clone-mse-swe-tempate.sh herunter 

https://inf-swe-git.technikum-wien.at/raw/MSE/SWE.git/master/clone-mse-swe-tempate.sh

Starten Sie das Script mit git-Bash oder Bash  mit folgenden Parametern

    ./clone-mse-swe-tempate.sh MSE-WS??-SWE <Main repo> <Second repo> <Username>

Mit den Anweisungen kopieren Sie das Template in Ihr lokales Projekt.

Achten Sie bitte darauf, dass immer BEIDE abgeben:

    git push all --all
	.\git-push-all.ps1
	./git-push-all.sh

Implementierung
---------------
Im Verzeichnis "Übungen" finden Sie für jede Abgabe eine Implementierung des jeweiligen Übungsinterface. Die Dokumentation finden Sie an dem Interface selbst.

Es spielt keine Rolle, wie die Abgabe-Klassen heißen oder in welchem Namespace sie liegen. Die Unit-Tests suchen nach genau einer Klasse, die das jeweilige Übungsinterface implementiert.

Ihre eigenen Klassen, die Sie im Rahmen der Übung implementieren, müssen ebenfalls bestimmte Interfaces implementieren. Diese leiten sich von den Übungsinterfaces bzw. den Unit-Tests ab.

Unit-Tests
----------
https://inf-swe-git.technikum-wien.at/tree/?f=MSE-SWE&r=SYSTEM/unit-tests.git&h=master

Am Jenkins wird Ihre Abgabe mit diesen Unit-Tests getestet. Diese Tests stehen Ihnen zur Verfügung. Sie können daher lokal, vorab überprüfen, ob Sie die Unit-Tests bestehen oder nicht.

In diesem Projekt ist auch dokumentiert, welche Interfaces Ihre Klassen implementieren müssen um die Unit-Tests zu bestehen.

Jenkins
-------
https://inf-swe-jenkins.technikum-wien.at/view/MSE-SWE/

Am Jenkins können Sie dann das Ergebnis Ihrer Abgabe sehen.

* Build aus dem Build-Verlauf auswählen
* Testergebnisse
* Konsolenausgabe

Sie dürfen so oft Sie möchten abgeben. Zu einem definierten Zeitpunkt (siehe Moodle) werden die Ergebnisse eingesammelt und ausgewertet. 
Am Ende der LV müssen alle Unit-Tests erfolgreich sein, mind. jedoch 50%. Zwischenergebnisse zählen nicht mehr. Die Anzahl der erfolgreich bestandenen Unit-Tests fließt in die Bewertung der Übung ein.