#### тест на психику

для того чтобы вытолкнуть из поверхности вектор нужно знать:
1. скорость вектора;
2. позицию вектора до столкновения;
3. параметры тела

под параметрами тела подразумевается реализация ``IPushing``, которая имеет метод ``Vector2 Normal(vector, velocity)``

в monogame-test-01 планируется выталкивать тела из поверхностей только в 4-х напралвениях, поэтому можно завести:
1. интерфейс ``ISurface``, который имел бы поля ``Float`` для указания положения поверхности и ``Direction`` для указания направления, в котором нужно выталкивать тело;
2. метод ``Vector2 Normal(this ISurface @this, Vector2 value)``, который давал бы нормаль от этой поверхности до входящего тела