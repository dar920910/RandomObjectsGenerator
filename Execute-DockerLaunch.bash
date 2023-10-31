#!/bin/bash
docker run --interactive --tty --rm random_objects_generator /usr/local/bin/RandomObjectsGenerator/RandomObjectsGenerator.App.CLI --count=10000
$SHELL