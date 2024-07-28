import os, re


def create_template_pot_file(translation_keys: dict):
     with open(os.path.join(os.path.dirname(os.path.abspath(__file__)), 'translations_template.pot'), 'w+', encoding="utf8") as file:
        file.write('''# GodotExtensionatorStarter - Translation template:
#
# FIRST AUTHOR <EMAIL@ADDRESS>, YEAR.
#
#, fuzzy
msgid ""
msgstr ""
"Project-Id-Version: GodotExtensionatorStarter\\n"
"MIME-Version: 1.0\\n"
"Content-Type: text/plain; charset=UTF-8\\n"
"Content-Transfer-Encoding: 8-bit\\n"

''')
        for translation_key, filepath in translation_keys.items():
            file.write(f'\n#: {filepath}\n')
            file.write(f'msgid "{translation_key}"\nmsgstr "{translation_key}"\n')


def find_translation_keys(dirpath: str):
    if os.path.isdir(dirpath):
        for root, _, files in os.walk(dirpath, topdown=True, followlinks=False):
            for file in list(filter(included_files_filter, files)):
                filepath = os.path.join(root, file)
                scan_file_for_translation_keys(filepath)
        
        create_template_pot_file(translation_keys)
                

def included_files_filter(file: str) -> bool:
    included_extensions = [".tscn", ".tres", ".res", ".gd", ".cs"]

    split_tuple = os.path.splitext(file)
    filename = split_tuple[0]
    file_extension = split_tuple[1]
    
    return not "." in filename and file_extension in included_extensions


def scan_file_for_translation_keys(filepath: str):
    files_readed.append(filepath)
    
    with open(filepath, 'r', encoding="utf8") as file:
        for line in file:
            for translation_key in translation_keys_from(line):
                translation_keys[translation_key] = os.path.relpath(filepath, ROOT_DIR).lstrip().replace("\\", "/")


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
    return re.findall(r'\b[A-Z]+(?:_[A-Z]+)+\b', value)



files_readed = []
translation_keys = {}

ROOT_DIR = find_godot_root_dir()

find_translation_keys(ROOT_DIR);