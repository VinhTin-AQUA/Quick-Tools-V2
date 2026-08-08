#!/bin/bash

cd quicktools-fe

ng build

cd ..

cp -a quicktools-fe/dist/quicktools-fe/browser/. QuickTools-BE/QuickTools.Windows/wwwroot/

