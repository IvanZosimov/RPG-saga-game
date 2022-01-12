using System;
using RPGSaga.Core;
using Xunit;

public class ConfigControllerTests
{
    [Theory]
    [InlineData("-i", "filename.json", "FileConfig", false)]
    [InlineData("-s", "filename.json", "KeyboardConfig", true)]
    [InlineData("-k", "20", "LineArgumentsConfig", false)]
    public void ChooseConfiguration_chooses_configuration_properly(string argument, string value, string typeOfConfig, bool serializationFlag)
    {
        // Arrange
        ConfigController controller = new ConfigController();
        string[] args = { argument, value };
        (IInputConfig, bool) resultedTuple;

        // Act
        resultedTuple = controller.ChooseConfiguration(args);

        // Assert
        Assert.True(resultedTuple.Item1.GetType().Name == typeOfConfig && resultedTuple.Item2 == serializationFlag);
    }

    [Theory]
    [InlineData("-k", "20", "-s", "filename.json", "LineArgumentsConfig", true)]
    [InlineData("-i", "filename.json", "-s", "filename.json", "FileConfig", true)]
    public void ChooseConfiguration_chooses_configuration_properly_with_mixed_arguments(string argument1, string value1, string argument2, string value2, string typeOfConfig, bool serializationFlag)
    {
        // Arrange
        ConfigController controller = new ConfigController();
        string[] args = { argument1, value1, argument2, value2 };
        (IInputConfig, bool) resultedTuple;

        // Act
        resultedTuple = controller.ChooseConfiguration(args);

        // Assert
        Assert.True(resultedTuple.Item1.GetType().Name == typeOfConfig && resultedTuple.Item2 == serializationFlag);
    }

    [Fact]
    public void ChooseConfiguration_chooses_configuration_properly_when_args_array_is_empty()
    {
        // Arrange
        ConfigController controller = new ConfigController();
        string[] args = new string[] { };
        (IInputConfig, bool) resultedTuple;

        // Act
        resultedTuple = controller.ChooseConfiguration(args);

        // Assert
        Assert.True(resultedTuple.Item1.GetType().Name == "KeyboardConfig" && resultedTuple.Item2 == false);
    }

    [Fact]
    public void ChooseConfiguration_throws_exception_when_arguments_are_not_valid()
    {
        // Arrange
        ConfigController controller = new ConfigController();
        string[] args = { "-p" };

        // Act
        Action act = () => controller.ChooseConfiguration(args);

        // Act/Assert
        Assert.Throws<ArgumentException>(act);
    }
}