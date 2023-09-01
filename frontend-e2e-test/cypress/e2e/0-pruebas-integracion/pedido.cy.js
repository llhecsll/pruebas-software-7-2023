describe("CRUD Pedido", () => {//Titulo
    //Antes que nada, abrir el navegador en el proyecto Frontend que es el puerto 8100
    beforeEach(() => {
        cy.visit("http://localhost:8100"); //Frontend de Produccion
    });

    //Servicio API - GetPedido()
    it("GetPedido()", () => {
        cy.wait(1000);//Esperar 1 seg.
        cy.get("ion-tab-button").eq(5).click(); // click en el TAB de Pedido
        cy.wait(1000);//Esperar 1 seg.

        cy.get("ion-item").should("be.visible")
        .should("not.have.length", "0"); //Verifica que exista al menos un (ion-item)
    });

    //Servicio API - addPedido
    it("addPedido", () => {
        cy.wait(1000);
        cy.get("ion-tab-button").eq(5).click();
        cy.wait(1000);

        // Ingresa los datos en los campos correspondientes
        //cy.get("#id").type("123");
        cy.get("#idUsuario").type("1");
        cy.get("#fechaPedido").type("2023-08-31");

        // Haz clic en el botón "Agregar Pedido"
        cy.get("#addPedido").click();

        // Verifica que los datos del pedido agregado sean correctos
       // cy.get("div").contains("strong", "ID:").next().should("contain", "123");
       // cy.get("div").contains("strong", "Id Usuario:").next().should("contain", "Usuario123");
        // ... Verifica otros campos ...

    });

    //Servicio API - updatePedido
    it("updatePedido", () => {
        cy.wait(1000);
        cy.get("ion-tab-button").eq(5).click();
        cy.wait(1000);

        // Ingresa el ID del pedido que deseas actualizar en el campo "id"
        const pedidoId = 1;
        cy.get("#idA").type(pedidoId);
        

        // Ingresa los nuevos datos en los campos correspondientes
        //cy.get("#id").type("1");
        cy.get("#idUsuario").type("1");
        cy.get("#fechaPedido").type("2023-08-31");
        // ... Ingresa otros campos que deseas actualizar ...

        // Haz clic en el botón "Actualizar Detalle Pedido"
        cy.get("#updatePedido").click();

        // Verifica que los datos del pedido actualizado sean correctos
        // cy.get("div").contains("strong", "ID:").next().should("contain", pedidoId);
        // cy.get("div").contains("strong", "Id Usuario:").next().should("contain", "NuevoUsuario123");
        // ... Verifica otros campos ...

    });

    //Servicio API - getPedidoById    
    it("getPedidoById", () => {
        cy.wait(1000);
        cy.get("ion-tab-button").eq(5).click();
        cy.wait(1000);

        // Ingresa el ID del pedido que deseas obtener en el campo "id"
        const pedidoId = 1;
        cy.get("#idB").type(pedidoId);

        // Haz clic en el botón "Obtener Pedido"
        cy.get("#getPedidoById").click();

        // Verifica que los datos del pedido obtenido sean correctos
        //cy.get("div").contains("strong", "ID:").next().should("contain", pedidoId);
        // ... Verifica otros campos ...

    });

    //Servicio API - getPedidoById   
    it("deletePedido", () => {
        cy.wait(1000);
        cy.get("ion-tab-button").eq(5).click();
        cy.wait(1000);

        // Ingresa el ID del pedido que deseas eliminar en el campo "id"
        const pedidoId = 102;
        cy.get("#idDel").type(pedidoId);

        // Haz clic en el botón "Eliminar Pedido"
        cy.get("#deletePedido").click();

        // Verifica que el pedido haya sido eliminado
        //cy.get("ion-item").should("not.contain", pedidoId);
        // ... Verifica otros elementos que confirmen la eliminación ...

        // Puedes hacer más verificaciones si es necesario
    });

});