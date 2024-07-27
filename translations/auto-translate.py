import os

def walk_dir_recursively(dirpath: str):
    if os.path.isdir(dirpath):
        for root, _, files in os.walk(dirpath, topdown=True, followlinks=False):
            # for dir in list(filter(lambda subdir: (not os.path.basename(subdir).startswith(".")), subdirs)):
            #     walk_dir_recursively(dir)
           
            for file in list(filter(included_files, files)):
                print(file)
                filepath = os.path.join(root, file)
                scan_file_for_translation_keys(filepath)
                

def included_files(file: str) -> bool:
    split_tuple = os.path.splitext(file)
    filename = split_tuple[0]
    file_extension = split_tuple[1]
    
    return not "." in filename and file_extension in included_extensions


def scan_file_for_translation_keys(filepath: str):
    files_readed.append(filepath)
    #print(filepath)
       


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


included_extensions = [".tscn", ".gd", ".cs"]

files_readed = []
translation_keys = {}

ROOT_DIR = find_godot_root_dir()

walk_dir_recursively(ROOT_DIR);