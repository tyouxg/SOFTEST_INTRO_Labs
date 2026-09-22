@Factorial
Feature: UsingCalculatorFactorial
  In order to avoid manual calculation
  As a calculator user
  I want to be told the factorial of a number

  Scenario: Calculating a normal factorial
    Given I have a calculator
    When I have entered 5 into the calculator and press factorial
    Then the factorial result should be 120

  Scenario: Factorial of zero
    Given I have a calculator
    When I have entered 0 into the calculator and press factorial
    Then the factorial result should be 1

  Scenario: Rejecting an unsupported factorial value
    Given I have a calculator
    When I have entered -1 into the calculator and press factorial
    Then factorial should be rejected