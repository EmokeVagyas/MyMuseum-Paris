import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-questionnaire',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './questionnaire.component.html',
  styleUrl: './questionnaire.component.css'
})
export class QuestionnaireComponent {
  questionnaireForm: FormGroup;
  currentStep = 0;

  questions = [
    {
      id: 1,
      question: 'What type of museums are you interested in?',
      controlName: 'museumType',
      type: 'checkbox',
      options: [
        'Historical',
        'Art',
        'Science & Technology',
        'Natural History',
        'Cultural & Ethnographic',
        'Other (ex. Fashion, Cinema)'
      ],
        next: (answer: string) => {
          if (answer === 'Historical') return 2;
          if (answer === 'Art') return 3;
          if (answer === 'Science & Technology') return 4;
          if (answer === 'Natural History') return 5;
          if (answer === 'Cultural & Ethnographic') return 6;
          return 0;
        }
    },
    {
      id: 2,
      question: 'What historical period are you interested in?',
      controlName: 'historicalPeriod',
      type: 'radio',
      options: [
        'Ancient (Egypt, Greece, Rome)',
        'Medieval (Middle Ages, Renaissance)',
        'Modern (World Wars, 20th Century)',
        'French (Revolution, Napoleon)',
      ],
    },
    {
      id: 3,
      question: 'What art style do you enjow the most?',
      controlName: 'artStyle',
      type: 'radio',
      options: [
        'Classical (Renaissance, Baroque, Neoclassicism)',
        'Modern (Post-Impressionism, Cubism, Surrealism)',
        'Contemporary (Pop Art, Abstract Expressionism, Minimalism)',
        'Impressionism (Monet, Degas, Renoir)',
        'Photography',
      ]
    },
    {
      id: 4,
      question: 'Which field of science are you interested in?',
      controlName: 'scienceField',
      type: 'radio',
      options: [
        'Space & Astronomy',
        'Phisics & Engineering',
        'Biology & Medicine',
        'Chemistry',
        'Geology & Paleontology',
      ]
    },
    {
      id: 5,
      question: 'Which area of natural history interests you the most?',
      controlName: 'naturalHistoryArea',
      type: 'radio',
      options: [
        'Dinosaurs & Prehistoric Life',
        'Human Evolution',
        'Marine Life & Oceanography',
        'Botany & Plant Life',
        'Geology & Earth Sciences',
        'Wildlife & Zoology',    
      ]
    },
    {
      id: 6,
      question: 'Which type of cultural and ettnographic content interests you?',
      controlName: 'culturalContent',
      type: 'radio',
      options: [
        'Ancient Civilizations',
        'Indigenous Cultures',
        'World Religions & Beliefs',
        'Cultural Artifacts & Traditions',
      ]
    },
    {
      id: 7,
      question: 'How old are you?',
      controlName: 'age',
      type: 'number',
      options: [
        'under 12',
        '12-18',
        '19-35',
        '36-65',
        'over 65',
      ],
    },
    {
      id: 8,
      question: 'Are you visiting with children?',
      controlName: 'children',
      type: 'radio',
      options: [
        'Yes',
        'No',
      ],
    },
    {
      id: 9,
      question: 'What type of museum size do you prefer?',
      controlName: 'size',
      type: 'radio',
      options: [
        'Small & Intimate',
        'Medium & Diverse',
        'Large & Comprehensive',
        'All sizes',
      ],
    },
    {
      id: 10,
      question: 'Do you prefer indoor or outdoor museums?',
      controlName: 'indoorOutdoor',
      type: 'radio',
      options: [
        'Indoor',
        'Outdoor',
        'Both',
      ],
    },
    {
      id: 11,
      question: 'Do you prefer guided tours or exploring on your own?',
      controlName: 'guidedTours',
      type: 'radio',
      options: [
        'Guided Tours',
        'Exploring on my own',
        'Both',
      ],
    },
    {
      id: 12,
      question: 'How much time do you usually spend in a museum?',
      controlName: 'timeSpent',
      type: 'radio',
      options: [
        '1-2 hours',
        '3-4 hours',
        'Half a day',
        'All of the above',
      ],
    },
    {
      id: 13,
      question: 'What is your budget for a museum visit? *If you are an EU citizen under 25 or under 26, you can visit most museums for free.',
      controlName: 'budget',
      type: 'radio',
      options: [
        'Free Entry',
        'Under 10€',
        '10-20€',
        'Over 20€',
        'I don\'t mind',
      ]
    },
    {
      id: 14,
      question: 'Do you need special facilities for your visit?',
      controlName: 'specialFacilities',
      type: 'checkbox',
      options: [
        'Wheelchair Accessible',
        'Audio Guides',
      ]
    },
    {
      id: 15,
      question: 'Are you intersted in palaces or royal residences with gardens?',
      controlName: 'palaces',
      type: 'radio',
      options: [
        'Yes',
        'No',
      ]
    },
  ];

  constructor(private fb: FormBuilder) {
    this.questionnaireForm = this.fb.group({});

    this.questions.forEach((question) => {
      this.questionnaireForm.addControl(
        question.controlName,
        this.fb.control('')
      );
    })
  };

  handleNextStep(answer?: string) {
  // If there's a next question based on the answer
  const nextStep = this.questions[this.currentStep]?.next?.('answer');
  if (nextStep !== undefined) {
    this.currentStep = this.questions.findIndex(q => q.id === nextStep);
  } else if (this.currentStep < this.questions.length - 1) {
    this.currentStep++;
  }
  
}
}
