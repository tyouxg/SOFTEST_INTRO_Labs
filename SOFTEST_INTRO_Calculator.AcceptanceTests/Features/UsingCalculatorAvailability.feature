@Availability
Feature: UsingCalculatorAvailability
  In order to calculate MTBF and Availability
  As someone who struggles with maths
  I want to be able to use my calculator to do this

  Scenario: Calculating MTBF
    Given I have a calculator
    When I have entered 900 and 10 into the calculator and press MTBF
    Then the result should be 90

  Scenario: Calculating Availability
    Given I have a calculator
    When I have entered 90 and 10 into the calculator and press Availability
    Then the result should be 0.9

  Scenario: Rejecting MTBF with zero failures
    Given I have a calculator
    When I have entered 900 and 0 into the calculator and press MTBF
    Then MTBF should be rejected

  Scenario: Rejecting Availability with a negative repair time
    Given I have a calculator
    When I have entered 90 and -5 into the calculator and press Availability
    Then Availability should be rejected

  Scenario: Calculating Availability from named reliability values
    Given I have a calculator
    And the reliability values are
    | MTBF | MTTR |
    | 90 | 10 |
    When I calculate Availability from these values
    Then the result should be 0.9
