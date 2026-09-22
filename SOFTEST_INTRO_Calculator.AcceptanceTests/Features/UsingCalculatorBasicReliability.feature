@BasicMusa
Feature: UsingCalculatorBasicReliability
  In order to calculate the Basic Musa model's failures and intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

  Scenario: Current failure intensity at the start of execution
    Given I have a calculator
    When I have entered 1, 10 and 0 into the calculator and press current failure intensity
    Then the result should be 1

  Scenario: Current failure intensity after some execution time
    Given I have a calculator
    When I have entered 1, 10 and 10 into the calculator and press current failure intensity
    Then the result should be 0.36787944117144233

  Scenario: Expected cumulative failures at the start of execution
    Given I have a calculator
    When I have entered 1, 10 and 0 into the calculator and press expected cumulative failures
    Then the result should be 0

  Scenario: Expected cumulative failures after some execution time
    Given I have a calculator
    When I have entered 1, 10 and 10 into the calculator and press expected cumulative failures
    Then the result should be 6.3212055882855767

  Scenario Outline: Rejecting invalid Basic Musa parameters
    Given I have a calculator
    When I have entered <lambda0>, <nu0> and <tau> into the calculator and press current failure intensity
    Then Basic Musa should be rejected

    Examples:
      | lambda0 | nu0 | tau |
      | 0       | 10  | 5   |
      | -1      | 10  | 5   |
      | 1       | 0   | 5   |
      | 1       | -10 | 5   |
      | 1       | 10  | -1  |