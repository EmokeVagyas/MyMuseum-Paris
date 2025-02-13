import json


def refactor_json(input_file, output_file):
    with open(input_file, 'r', encoding='utf-8') as f:  # Fix UTF-8 BOM issue
        museums = json.load(f)  # Load the JSON data

    if not isinstance(museums, list):
        museums = [museums]  # Ensure it's a list

    for museum in museums:
        museum_id = museum.get("MuseumId")

        # Transform Accessibility field
        museum["Accessibility"] = [
            {"MuseumId": museum_id, "Accessibility": acc} for acc in museum.get("Accessibility", [])]

        # Transform Languages field
        museum["Languages"] = [{"MuseumId": museum_id, "Language": lang}
                               for lang in museum.get("Languages", [])]

    with open(output_file, 'w', encoding='utf-8') as f:
        # Save the transformed JSON
        json.dump(museums, f, indent=4, ensure_ascii=False)


if __name__ == "__main__":
    refactor_json("museums-old.json", "museums.json")
    print("Refactoring complete! Check output.json")
