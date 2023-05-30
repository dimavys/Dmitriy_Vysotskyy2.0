@DragAndDropTag
Feature: User can drag and drop items
    As a user
    I want to drag and drop 2 pictures to basket
    
    Scenario: user can add 2 imgs to trash:
        Given a user has selected "High Tatras 3" and "High Tatras 4" imgs
        When user drag and drops them to trash
        Then images are in trash