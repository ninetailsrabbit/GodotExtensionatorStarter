import os, re

def find_translation_keys(dirpath: str):
    if os.path.isdir(dirpath):
        for root, _, files in os.walk(dirpath, topdown=True, followlinks=False):
            for file in list(filter(included_files_filter, files)):
                filepath = os.path.join(root, file)
                scan_file_for_translation_keys(filepath)
                

def included_files_filter(file: str) -> bool:
    included_extensions = [".tscn", ".gd", ".cs"]

    split_tuple = os.path.splitext(file)
    filename = split_tuple[0]
    file_extension = split_tuple[1]
    
    return not "." in filename and file_extension in included_extensions


def scan_file_for_translation_keys(filepath: str):
    files_readed.append(filepath)
    
    with open(filepath, 'r', encoding="utf8") as file:
        for line in file:
            for translation_key in translation_keys_from(line):
                translation_keys[translation_key] = translation_key


def find_godot_root_dir() -> str:
    initial_path = os.path.dirname(os.path.abspath(__file__))
    current_path = os.path.abspath(os.path.join(initial_path, os.pardir))
    root_dir = ""

    while not root_dir and os.path.isdir(current_path):
        for files in os.walk(current_path):
            for file in files:
                if "project.godot" in file:
                    root_dir = current_path
                    break

        current_path = os.path.abspath(os.path.join(current_path, os.pardir))
            
    return root_dir

def translation_keys_from(value: str):
    return re.findall(r'\b([A-Z]+_[A-Z]+)+\b', value)



files_readed = []
translation_keys = {}

ROOT_DIR = find_godot_root_dir()

find_translation_keys(ROOT_DIR);

print(translation_keys)